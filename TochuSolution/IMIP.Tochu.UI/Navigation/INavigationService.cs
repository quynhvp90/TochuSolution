using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.UI.Navigation
{
    public interface INavigationService
    {
        ViewModelBase? CurrentPage { get; }
        bool CanGoBack { get; }

        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
        void NavigateTo<TViewModel>(Action<TViewModel> configure)
            where TViewModel : ViewModelBase;

        void OpenWindow<TViewModel>() where TViewModel : ViewModelBase;
        void OpenWindow<TViewModel>(Action<TViewModel> configure)
            where TViewModel : ViewModelBase;

        void GoBack();

        event Action? CurrentPageChanged;
        event EventHandler<ViewModelBase>? WindowRequested;
    }
}
