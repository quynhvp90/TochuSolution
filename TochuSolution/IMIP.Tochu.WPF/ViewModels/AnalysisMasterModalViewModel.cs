using IMIP.Tochu.Core.models;
using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class AnalysisMasterModalViewModel : NotifyBase
    {
        // Fired when the modal should close.
        // Argument: selected NOUSCD string, or null if cancelled.
        public event Action<string?>? RequestClose;

        private string _filterProduct;
        private VI_SeinouMstSE_Model? _selectedItem;

        // Full unfiltered list loaded from DB
        private ObservableCollection<VI_SeinouMstSE_Model> _allItems = new();

        public AnalysisMasterModalViewModel(string productName)
        {
            _filterProduct = productName ?? string.Empty;

            SelectCommand = new RelayCommand(ExecuteSelect, CanSelect);
            CancelCommand = new RelayCommand(_ => RequestClose?.Invoke(null));

            LoadData();
        }

        // ── Properties ────────────────────────────────────────────────────────

        /// <summary>Filter text bound to the search field (pre-filled with Field7 value).</summary>
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
                if (string.IsNullOrWhiteSpace(_filterProduct))
                    return _allItems;

                var filtered = _allItems
                    .Where(x => x.PRODUCT != null &&
                                x.PRODUCT.Contains(_filterProduct,
                                    StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return new ObservableCollection<VI_SeinouMstSE_Model>(filtered);
            }
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

        // ── Commands ──────────────────────────────────────────────────────────

        public ICommand SelectCommand { get; }
        public ICommand CancelCommand { get; }

        // ── Private helpers ───────────────────────────────────────────────────

        private void LoadData()
        {
            // TODO: replace with actual repository / service call
            // Example:  _allItems = new ObservableCollection<VI_SeinouMstSE_Model>(
            //               _repository.GetSeinouMstSE());
            //
            // For now the list stays empty; the grid will populate once
            // the real data source is wired up.
            _allItems = new ObservableCollection<VI_SeinouMstSE_Model>();
            OnPropertyChanged(nameof(FilteredItems));
        }

        private bool CanSelect(object? _) => SelectedItem != null;

        private void ExecuteSelect(object? _)
        {
            if (SelectedItem == null) return;
            RequestClose?.Invoke(SelectedItem.NOUSCD);
        }
    }
}
