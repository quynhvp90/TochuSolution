using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using IMIP.Tochu.UI.ViewModels;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly INavigationService _navigationService;
        public MainWindow()
        {
            InitializeComponent();
        }
        public MainWindow(MainViewModel mainView, INavigationService navigationService)
        {
            InitializeComponent();
            DataContext = mainView;
            _navigationService = navigationService;
            _navigationService.WindowRequested += OnWindowRequested;
        }

        private void OnWindowRequested(object? sender, ViewModelBase e)
        {
            // Handle window request
        }   
    }
}