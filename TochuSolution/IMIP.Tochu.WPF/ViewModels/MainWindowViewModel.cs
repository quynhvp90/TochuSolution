using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels.Shared;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class MainWindowViewModel : ViewModelBaseWPF
    {

        private ViewModelBaseWPF _currentView;
        public ViewModelBaseWPF CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(INavigationService navigation, IAppDataContext appDataContext) : base(navigation, appDataContext)
        {
            if (_navigation is NavigationService nav)
            {
                nav.CurrentViewChanged += () =>
                {
                    CurrentView = nav.CurrentView;
                };
                CurrentView = nav.CurrentView;
            }
        }

    }
}
