using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using IMIP.Tochu.WPF.Views.Windows;
using Infragistics.Windows.DataPresenter;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class SearchViewModel : ViewModelBaseWPF
    {
        private readonly ISENINOUDATAService _sENINOUDATAService;
        private readonly IJuchuuRCSService _juchuuRCSService;
        private CancellationTokenSource _cts;
        // --- Data state ---
        private ObservableCollection<T0000RR_Juchuu_RCS_Model> _juchuuRCSItems;
        private T0000RR_Juchuu_RCS_Model _selectedJuchuuRCSItem;

        private ObservableCollection<SI_SEINOUDATA_Model> _seninouDataItems;
        private SI_SEINOUDATA_Model _selectedSeninouDataItem;

        // Search parameters
        private bool _isSearching = false;
        private string _searchText = "";
        private DateTime? _startNoukidate = DateTime.Today.AddDays(-30);
        private DateTime? _endNoukidate = DateTime.Today;
        // ── Sort state ──────────────────────────────────────────────
        private string _sortField = "JuchuuNO";
        private bool _sortAscending = true;
        // Paging state
        public PagingViewModel JuChuuPaging { get; } = new();
        public PagingViewModel SeninouDataPaging { get; } = new();
        public int TotalSeninouCount
        {
            get => SeninouDataPaging.TotalCount;
        }
        // public properties for data binding
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                _ = GetJuchuuRCS();
            }
        }
        public DateTime? StartNoukidate
        {
            get => _startNoukidate;
            set
            {
                _startNoukidate = value;
                OnPropertyChanged();
                _ = GetJuchuuRCS();
            }
        }
        public DateTime? EndNoukidate
        {
            get => _endNoukidate;
            set
            {
                _endNoukidate = value;
                OnPropertyChanged();
                _ = GetJuchuuRCS();
            }
        }
        public string SortField
        {
            get => _sortField;
            set => SetProperty(ref _sortField, value);
        }

        public bool SortAscending
        {
            get => _sortAscending;
            set => SetProperty(ref _sortAscending, value);
        }
       
        public ObservableCollection<T0000RR_Juchuu_RCS_Model> JuchuuRCSItems
        {
            get => _juchuuRCSItems;
            set
            {
                SetProperty(ref _juchuuRCSItems, value);
            }
        }

        /// <summary>Currently selected row in the Data Table.</summary>
        public T0000RR_Juchuu_RCS_Model SelectedJuchuuRCSItem
        {
            get => _selectedJuchuuRCSItem;
            set
            {
                if (SetProperty(ref _selectedJuchuuRCSItem, value) && value != null)
                {
                    SeninouDataPaging.GoTo(1);  // reset for paging
                    _ = GetSeinouData(1, JuChuuPaging.PageSize);
                    NotifyAll();
                }
            }
        }

        public ObservableCollection<SI_SEINOUDATA_Model> SeninouDataItems
        {
            get => _seninouDataItems;
            set => SetProperty(ref _seninouDataItems, value);
        }
        public SI_SEINOUDATA_Model SelectedSeninouDataItem
        {
            get => _selectedSeninouDataItem;
            set => SetProperty(ref _selectedSeninouDataItem, value);
        }

        // Commands
        public ICommand GoBackCommand { get; }
        public ICommand Search { get; }
        public ICommand EditCommand { get; }
        public ICommand NewCommand { get; }

        public SearchViewModel(INavigationService nav, ISENINOUDATAService sENINOUDATAService, IJuchuuRCSService juchuuRCSService, IAppDataContext appDataContext) : base(nav, appDataContext)
        {
            _sENINOUDATAService = sENINOUDATAService;
            _juchuuRCSService = juchuuRCSService;
            if (appDataContext is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(BranchCode))
                    {
                        _ = GetJuchuuRCS();
                    }
                };
            }
            // set window state to maximized when this ViewModel is initialized
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            // Initialize commands
            GoBackCommand = new RelayCommand(() => _navigation.GoBack());
            Search = new RelayCommand(
                execute: async () => await GetJuchuuRCS(),
                canExecute: () => !_isSearching
            );
            EditCommand = new RelayCommand(
                execute: () => OnEdit(),
                canExecute: () => SelectedSeninouDataItem != null 
            );
            NewCommand = new RelayCommand(
                execute: () => OnNew(),
                canExecute: () => SelectedJuchuuRCSItem != null
            );
            // Heald events;
            JuChuuPaging.PageChanged += (page, size) => _ = GetJuchuuRCS(page, size);
            SeninouDataPaging.PageChanged += (page, size) => _ = GetSeinouData(page, size);
            // GetProducts();
            _ = GetJuchuuRCS();
        }
        private void OnEdit()
        {
            if (SelectedJuchuuRCSItem == null) return;
            _navigation.OpenWindow<Registration, RegistrationViewModel>(vm => vm.SetJuchuuRCS(SelectedJuchuuRCSItem, SelectedSeninouDataItem), win => win.InitUI());
        }
        private void OnNew()
        {
            _navigation.OpenWindow<Registration, RegistrationViewModel>(vm => vm.SetJuchuuRCS(SelectedJuchuuRCSItem, null), win => win.InitUI());
        }
        private void NotifyAll()
        {
            OnPropertyChanged(nameof(TotalSeninouCount));
            ((RelayCommand)EditCommand).RaiseCanExecuteChanged();
            ((RelayCommand)NewCommand).RaiseCanExecuteChanged();
            ((RelayCommand)Search).RaiseCanExecuteChanged();
        }
        public async Task GetJuchuuRCS(int pageIndex = 1, int pageSize = 20)
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();
            var token = _cts.Token;

            try
            {
                await Task.Delay(300, token);

                if (_isSearching) return;
                _isSearching = true;

                JuchuuPagingRequest paging = new JuchuuPagingRequest()
                {
                    PageIndex = pageIndex,
                    PageSize = pageSize,
                    SortAscending = SortAscending,
                    SortField = SortField,
                    JuchuuKyotenCD = _appDataContext.BranchCode,
                    StartNouki = _startNoukidate ?? DateTime.Today.AddDays(-30),
                    EndNouki = _endNoukidate ?? DateTime.Today,
                };

                var result = await _juchuuRCSService.GetJuchuuRCSAsync(paging);

                Application.Current.Dispatcher.Invoke(() =>
                {
                    SelectedJuchuuRCSItem = null;
                    JuChuuPaging.PageSize = pageSize;
                    JuChuuPaging.CurrentPage = pageIndex;
                    JuChuuPaging.Update(result.TotalCount);
                    JuchuuRCSItems = new ObservableCollection<T0000RR_Juchuu_RCS_Model>(result.Items);
                    NotifyAll();
                });
            }
            catch (OperationCanceledException)
            {
                // Search was canceled, no need to show an error message
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Invalid search input: {ex.Message}");
            }
            finally
            {
                _isSearching = false;
            }
        }
        public void OnJuchuuRCSortChanged(string field)
        {
            if (SortField == field)
                SortAscending = !SortAscending;
            else
            {
                SortField = field;
                SortAscending = true;
            }
            JuChuuPaging.GoTo(1);
        }
        public async Task GetSeinouData(int pageIndex = 1, int pageSize = 20)
        {
            await Task.Delay(300);
            SeninouDataPagingRequest paging = new SeninouDataPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                JuchuuRCS = SelectedJuchuuRCSItem
            };
            var result = await _sENINOUDATAService.GetSENINOUDATAAsync(paging).ConfigureAwait(true);
            SelectedSeninouDataItem = null;
            SeninouDataPaging.PageSize = pageSize;
            SeninouDataPaging.CurrentPage = pageIndex;
            SeninouDataPaging.Update(result.TotalCount);
            SeninouDataItems = new ObservableCollection<SI_SEINOUDATA_Model>(result.Items);
            //NotifyAll();

        }
    }
}
