using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using IMIP.Tochu.WPF.Views.Windows;
using OfficeOpenXml.Export.HtmlExport.StyleCollectors.StyleContracts;
using OfficeOpenXml.FormulaParsing.LexicalAnalysis;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class SearchViewModel : ViewModelBaseWPF
    {
        private readonly ISENINOUDATAService _sENINOUDATAService;
        private readonly IJuchuuRCSService _juchuuRCSService;
        // --- Data state ---
        private ObservableCollection<T0000RR_Juchuu_RCS_Model> _juchuuRCSItems;
        private T0000RR_Juchuu_RCS_Model _selectedJuchuuRCSItem;

        private ObservableCollection<SI_SEINOUDATA_Model> _seninouDataItems;
        private SI_SEINOUDATA_Model _selectedSeninouDataItem;

        // Search parameters
        private string _searchText = "31011";
        private DateTime? _startNoukidate = DateTime.Today.AddDays(-30);
        private DateTime? _endNoukidate = DateTime.Today;
        // ── Sort state ──────────────────────────────────────────────
        private string _sortField = "JuchuuNO";
        private bool _sortAscending = true;
        // Paging state
        public PagingViewModel JuChuuPaging { get; } = new();
        public PagingViewModel SeninouDataPaging { get; } = new();
        // public properties for data binding
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                GetJuchuuRCS();
            }
        }
        public DateTime? StartNoukidate
        {
            get => _startNoukidate;
            set
            {
                _startNoukidate = value;
                OnPropertyChanged();
                GetJuchuuRCS();
            }
        }
        public DateTime? EndNoukidate
        {
            get => _endNoukidate;
            set
            {
                _endNoukidate = value;
                OnPropertyChanged();
                GetJuchuuRCS();
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
                    JuChuuPaging.GoTo(1);  // reset về trang 1
                    _ = GetJuchuuRCS(1, JuChuuPaging.PageSize);
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
        public ICommand SelectItem { get; }
        public ICommand EditCommand { get; }

        public SearchViewModel(INavigationService nav, ISENINOUDATAService sENINOUDATAService, IJuchuuRCSService juchuuRCSService, IAppDataContext appDataContext) : base(nav, appDataContext)
        {
            _sENINOUDATAService = sENINOUDATAService;
            _juchuuRCSService = juchuuRCSService;
            // set window state to maximized when this ViewModel is initialized
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            // Initialize commands
            GoBackCommand = new RelayCommand(() => _navigation.GoBack());
            Search = new RelayCommand(async () => _ = GetJuchuuRCS());
            SelectItem = new RelayCommand<T0000RR_Juchuu_RCS_Model>(OnSelectItem);
            EditCommand = new RelayCommand(
                execute: () => OnEdit(),
                canExecute: () => SelectedJuchuuRCSItem != null  // ← chỉ enabled khi có selection
            );
            // Heald events;
            JuChuuPaging.PageChanged += (page, size) => _ = GetJuchuuRCS(page, size);
            SeninouDataPaging.PageChanged += (page, size) => _ = GetSeinouData(page, size);
            // GetProducts();
            _ =GetJuchuuRCS();
        }
        private void OnEdit()
        {
            if (SelectedJuchuuRCSItem == null) return;
            _navigation.OpenWindow<Registration, RegistrationViewModel>(null, win => win.InitUI());
        }
        // --- Select item handler ---
        private void OnSelectItem(T0000RR_Juchuu_RCS_Model? item)
        {
            if (item is null) return;


            _navigation.OpenWindow<Registration, RegistrationViewModel>(null, win =>
            {
                win.InitUI();
            });
        }

        

        public async Task GetJuchuuRCS(int pageIndex = 1, int pageSize = 20)
        {
            await Task.Delay(300);
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
                JuChuuPaging.PageSize = pageSize;
                JuChuuPaging.CurrentPage = pageIndex;
                JuChuuPaging.Update(result.TotalCount);
                JuchuuRCSItems = new ObservableCollection<T0000RR_Juchuu_RCS_Model>(result.Items);
            });
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
            SeninouDataItems = new ObservableCollection<SI_SEINOUDATA_Model>(result.Items);

        }
    }
}
