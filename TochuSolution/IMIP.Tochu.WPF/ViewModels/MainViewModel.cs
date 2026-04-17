using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MainViewModel : ViewModelBaseWPF
    {

        public string UserName { get; set; }

        public ICommand GoSearchCommand { get; }
        public ICommand GoMasterCommand { get; }

        public MainViewModel(INavigationService nav) : base(nav)
        {
            UserName = "Default User";
            if (Application.Current != null && Application.Current.MainWindow != null)
                Application.Current.MainWindow.WindowState = WindowState.Normal;
            GoSearchCommand = new RelayCommand(() => GoToSearch());
            GoMasterCommand = new RelayCommand(() => GoToMaster());
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
