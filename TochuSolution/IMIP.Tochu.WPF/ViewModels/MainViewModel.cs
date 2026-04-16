using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;

        public string UserName { get; set; }

        public ICommand GoSearchCommand { get; }
        public ICommand GoMasterCommand { get; }

        public MainViewModel(INavigationService nav)
        {
            _nav = nav;

            UserName = "Default User";
            if (Application.Current != null && Application.Current.MainWindow != null)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            GoSearchCommand = new RelayCommand(() => GoToSearch());
            GoMasterCommand = new RelayCommand(() => GoToMaster());
        }

        public void GoToSearch()
        {
            _nav.NavigateTo<SearchViewModel>();
        }
        public void GoToMaster()
        {
            _nav.NavigateTo<MasterViewModel>();
        }
    }
}
