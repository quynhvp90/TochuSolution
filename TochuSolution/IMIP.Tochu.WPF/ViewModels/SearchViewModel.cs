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
        private readonly IProductService _productService;
        private readonly IJuchuuRCSService _juchuuRCSService;
        private ObservableCollection<T0000RR_Juchuu_RCS_Model> _juchuuRCSItems;
        private T0000RR_Juchuu_RCS_Model _selectedJuchuuRCSItem;
        public ObservableCollection<SI_TANTOU_Model> Users { get; } = new();
        public ObservableCollection<VI_Product_Model> Products { get; } = new();

        private string _searchText = string.Empty;
        private DateTime? _startNoukidate = DateTime.Today.AddDays(-30);
        private DateTime? _endNoukidate = DateTime.Today;
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
        public ObservableCollection<T0000RR_Juchuu_RCS_Model> JuchuuRCSItems
        {
            get => _juchuuRCSItems;
            set
            {
                _juchuuRCSItems = value;
                SetProperty(ref _juchuuRCSItems, value);
            }
        }

        /// <summary>Currently selected row in the Data Table.</summary>
        public T0000RR_Juchuu_RCS_Model SelectedJuchuuRCSItem
        {
            get => _selectedJuchuuRCSItem;
            set
            {
                if (SetProperty(ref _selectedJuchuuRCSItem, value))
                    // Re-evaluate Edit CanExecute when selection changes
                    ((RelayCommand)EditCommand).RaiseCanExecuteChanged();
            }
        }

        private ObservableCollection<SI_SEINOUDATA_Model> _resultItems;
        /// <summary>Rows displayed in the lower Result Table.</summary>
        public ObservableCollection<SI_SEINOUDATA_Model> ResultItems
        {
            get => _resultItems;
            set => SetProperty(ref _resultItems, value);
        }

        private SI_SEINOUDATA_Model _selectedResultItem;
        /// <summary>Currently selected row in the Result Table.</summary>
        public SI_SEINOUDATA_Model SelectedResultItem
        {
            get => _selectedResultItem;
            set => SetProperty(ref _selectedResultItem, value);
        }


        public ICommand GoBackCommand { get; }
        public ICommand Search { get;}
        public ICommand EditCommand { get; }

        public SearchViewModel(INavigationService nav, IProductService productService, IJuchuuRCSService juchuuRCSService, IAppDataContext appDataContext) : base(nav, appDataContext)
        {
            _productService = productService;
            _juchuuRCSService = juchuuRCSService;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            GoBackCommand = new RelayCommand(() => _navigation.GoBack());
            Search = new RelayCommand(async () => GetJuchuuRCS());
            EditCommand = new RelayCommand<VI_Product_Model>(OnEdit);
            // GetProducts();
        }
        // --- Edit button handler ---
        private void OnEdit(VI_Product_Model? product)
        {
            if (product is null) return;

            //MessageBox.Show(
            //    $"Product: {product.Name}\nPrice: {product.Price}",
            //    "Edit Product",
            //    MessageBoxButton.OK,
            //    MessageBoxImage.Information);

            _navigation.OpenWindow<Registration, RegistrationViewModel>(null, win => { 
                win.InitUI();
            });
        }
        private async Task GetProducts()
        {
            var products = await _productService.GetProductsAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
            OnPropertyChanged(nameof(Products));
        }
        public async void GetJuchuuRCS()
        {
            await Task.Delay(300);
            JuchuuPaging paging = new JuchuuPaging()
            {
                PageSize = 1000,
                JuchuuKyotenCD = _appDataContext.BranchCode,
                StartNouki = _startNoukidate,
                EndNouki = _endNoukidate
            };
            if (string.IsNullOrEmpty(paging.JuchuuKyotenCD))
            {
                paging.JuchuuKyotenCD = _appDataContext.BranchCode;
            }
            if (paging.StartNouki == null)
            {
                paging.StartNouki = DateTime.Today.AddDays(-30);
            }
            if (paging.EndNouki == null)
            {
                paging.EndNouki = DateTime.Today;
            }   
            var result = await _juchuuRCSService.GetJuchuuRCSAsync(paging);
            MessageBox.Show($"Total: {result.TotalCount}\nItems: {string.Join(", ", result.Items.Select(i => i.JuchuuNO))}");
        }
        
    }
}
