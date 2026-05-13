using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.models;
using IMIP.Tochu.Core.Models.Paging;
using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class AnalysisMasterModalViewModel : ViewModelBaseWPF
    {
        private readonly IVI_SeinouMstSEService _seinouMstSEService;
        // Fired when the modal should close.
        // Argument: selected NOUSCD string, or null if cancelled.
        public event Action<string?>? RequestClose;

        private string _filterProduct;
        private string FilterUserHinban { set; get; }
        private VI_SeinouMstSE_Model? _selectedItem;

        // Full unfiltered list loaded from DB
        private ObservableCollection<VI_SeinouMstSE_Model> _allItems = new();
        public string FilterProduct
        {
            get => _filterProduct;
            set
            {
                if (SetProperty(ref _filterProduct, value))
                    OnPropertyChanged(nameof(FilteredItems));
            }
        }
        /// <summary>Filtered view of the master list.</summary>
        public ObservableCollection<VI_SeinouMstSE_Model> FilteredItems
        {
            get
            {
                return _allItems;
            }
            set => SetProperty(ref _allItems, value);
        }

        /// <summary>Currently highlighted row in the DataGrid.</summary>
        public VI_SeinouMstSE_Model? SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (SetProperty(ref _selectedItem, value))
                    (SelectCommand as RelayCommand)?.RaiseCanExecuteChanged();
            }
        }
        public PagingViewModel analysisMasterPaging { get; } = new();
        private Action<string?>? _onSelected;

        // ── Commands ──────────────────────────────────────────────────────────
        public ICommand SelectCommand { get; }
        public ICommand CancelCommand { get; }

        public AnalysisMasterModalViewModel(IVI_SeinouMstSEService seinouMstSEService, 
            INavigationService navigationService, IAppDataContext appDataContext): base(navigationService, appDataContext)
        {
            _seinouMstSEService = seinouMstSEService;
            SelectCommand = new RelayCommand(ExecuteSelect, CanSelect);
            CancelCommand = new RelayCommand(_ => { _onSelected?.Invoke(null); RequestClose?.Invoke(null); });
            analysisMasterPaging.PageChanged += (page, size) => _ = LoadData(page, size);
        }
        /// <summary>
        /// Called by navigation after the window/VM pair is created.
        /// </summary>
        /// <param name="productName">Value from Field7 (UserHinban) to pre-fill the filter.</param>
        /// <param name="onSelected">Callback invoked with the chosen NOUSCD (or null if cancelled).</param>
        public async void Initialize(string userHinban, Action<string?> onSelected)
        {
            _onSelected = onSelected;
            FilterProduct = userHinban;
            await LoadData();
        }

        private async Task LoadData(int pageIndex = 1, int pageSize = 20)
        {
            var request = new VI_SeinouMstSEPagingRequest()
            {
                PageIndex = pageIndex,
                PageSize = pageSize,
                ProductName = FilterProduct
            };
            var result = await _seinouMstSEService.GetByProductAndNouscdAsync(request);
            FilteredItems = new ObservableCollection<VI_SeinouMstSE_Model>(result.Items);
            analysisMasterPaging.Update(result.TotalCount);
            analysisMasterPaging.PageSize = result.PageSize;
            analysisMasterPaging.CurrentPage = result.PageIndex;
            SelectedItem = null;
        }

        private bool CanSelect() => SelectedItem != null;

        private void ExecuteSelect()
        {
            if (SelectedItem == null) return;
            _onSelected?.Invoke(SelectedItem.NOUSCD);
            RequestClose?.Invoke(SelectedItem.NOUSCD);
        }
    }
}
