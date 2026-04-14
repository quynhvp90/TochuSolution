using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System.Windows.Input;

namespace IMIP.Tochu.UI.ViewModels
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

            GoSearchCommand = new RelayCommand(() => _nav.NavigateTo<SearchViewModel>());
            GoMasterCommand = new RelayCommand(() => _nav.NavigateTo<MasterViewModel>());
        }
    }
}
