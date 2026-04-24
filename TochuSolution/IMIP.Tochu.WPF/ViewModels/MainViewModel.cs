using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MainViewModel : ViewModelBaseWPF
    {
        private readonly IAppDataContext _appDataContext;
        public string UserName { get; set; }

        public ICommand GoSearchCommand { get; }
        public ICommand GoMasterCommand { get; }

        public MainViewModel(INavigationService nav, IAppDataContext appDataContext) : base(nav)
        {
            _appDataContext = appDataContext;
            UserName = "Default User";
            if (Application.Current != null && Application.Current.MainWindow != null)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            GoSearchCommand = new RelayCommand(() => GoToSearch());
            GoMasterCommand = new RelayCommand(() => GoToMaster());
        }

        protected override void OnNavigatedTo(bool isBack)
        {
            base.OnNavigatedTo(isBack);
            if (_appDataContext.CurrentUser != null)
                UserName = _appDataContext.CurrentUser.Name;
        }

        public void GoToSearch()
        {
            _navigation.NavigateTo<SearchViewModel>();
        }
        public void GoToMaster()
        {
            _navigation.NavigateTo<MasterViewModel>();
        }
    }
}
