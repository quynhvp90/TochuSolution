using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System.Windows.Input;

namespace IMIP.Tochu.UI.ViewModels
{
    public class SearchViewModel : ViewModelBase
    {
        private readonly INavigationService _nav;

        public string SearchText { get; set; }

        public ICommand GoBackCommand { get; }

        public SearchViewModel(INavigationService nav)
        {
            _nav = nav;

            GoBackCommand = new RelayCommand(() => _nav.GoBack());
        }
    }
}
