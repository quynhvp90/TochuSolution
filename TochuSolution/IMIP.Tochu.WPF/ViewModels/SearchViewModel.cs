using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using IMIP.Tochu.WPF.Views.Windows;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class SearchViewModel : ViewModelBaseWPF
    {
        private readonly IProductService _productService;
        private CancellationTokenSource _cts;
        public ObservableCollection<UserModel> Users { get; } = new();
        public ObservableCollection<ProductModel> Products { get; } = new();

        private string _searchText = string.Empty;
        public string SearchText
        {
            get => _searchText;
            set
            {
                _searchText = value;
                OnPropertyChanged();
                StartSearch();
            }
        }

        public ICommand GoBackCommand { get; }
        public ICommand LoadProducts { get;}
        public ICommand EditCommand { get; }

        public SearchViewModel(INavigationService nav, IProductService productService) : base(nav)
        {
            _productService = productService;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            GoBackCommand = new RelayCommand(() => _navigation.GoBack());
            LoadProducts = new RelayCommand(async () => await GetProducts());
            EditCommand = new RelayCommand<ProductModel>(OnEdit);
            GetProducts();
        }
        private void StartSearch()
        {
            _cts?.Cancel();
            _cts = new CancellationTokenSource();

            _ = SearchAsync(_searchText, _cts.Token);
        }
        // --- Edit button handler ---
        private void OnEdit(ProductModel? product)
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
            var products = await _productService.SearchProductAsync();
            Products.Clear();
            foreach (var product in products)
            {
                Products.Add(product);
            }
            OnPropertyChanged(nameof(Products));
        }
        private async Task SearchAsync(string keyword, CancellationToken token)
        {
            try
            {
                // 🔥 debounce (tránh spam API)
                await Task.Delay(300, token);

                if (token.IsCancellationRequested)
                    return;

                var result = await _productService.GetProductsAsync(keyword);

                if (token.IsCancellationRequested)
                    return;

                Products.Clear();
                foreach (var item in result)
                {
                    Products.Add(item);
                }
            }
            catch (TaskCanceledException)
            {
                // ignore
            }
        }
    }
}
