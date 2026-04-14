using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.UI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly INavigationService _navigation;

        private ViewModelBase _currentView;
        public ViewModelBase CurrentView
        {
            get => _currentView;
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainWindowViewModel(INavigationService navigation)
        {
            _navigation = navigation;
            //MainVM = new MainViewModel(this);
            //SearchVM = new SearchViewModel(this);
            //MasterVM = new MasterViewModel(this);

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
