using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System.Windows.Input;

namespace IMIP.Tochu.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;
        public ViewModelBase? CurrentView => _nav.CurrentPage;
        public bool CanGoBack => _nav.CanGoBack;
        public string PageTitle => CurrentView switch
        {
            SearchViewModel => "Search",
            MasterViewModel => "Master",
            _ => "My Application"
        };
        public ICommand NavigateToSearchCommand { get; }
        public ICommand NavigateToMasterCommand { get; }
        public ICommand GoBackCommand { get; }

        public MainViewModel(INavigationService nav)
        {
            _nav = nav;

            NavigateToSearchCommand = new RelayCommand(NavigateToSearch);
            NavigateToMasterCommand = new RelayCommand(NavigateToMaster);
            GoBackCommand = new RelayCommand(GoBack, () => _nav.CanGoBack);

            _nav.CurrentPageChanged += () =>
            {
                OnPropertyChanged(nameof(CurrentView));
                OnPropertyChanged(nameof(CanGoBack));
                OnPropertyChanged(nameof(PageTitle));
            };
        }

        private void NavigateToSearch() => _nav.NavigateTo<SearchViewModel>();
        private void NavigateToMaster() => _nav.NavigateTo<MasterViewModel>();
        private void GoBack() => _nav.GoBack();
    }
}
