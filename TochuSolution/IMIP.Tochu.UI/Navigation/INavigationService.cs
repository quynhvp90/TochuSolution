using IMIP.Tochu.UI.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMIP.Tochu.UI.Navigation
{
    public interface INavigationService
    {
        ViewModelBase? CurrentView { get; }
        bool CanGoBack { get; }

        void NavigateTo<TViewModel>() where TViewModel : ViewModelBase;
        void NavigateTo<TViewModel>(Action<TViewModel> configure)
            where TViewModel : ViewModelBase;

        // OPEN WINDOW
        void OpenWindow<TWindow, TViewModel>(
            Action<TViewModel>? configureVm = null,
            Action<TWindow>? configureWindow = null)
            where TWindow : Window
            where TViewModel : ViewModelBase;

        bool? OpenDialog<TWindow, TViewModel>(
            Action<TViewModel>? configureVm = null,
            Action<TWindow>? configureWindow = null)
            where TWindow : Window
            where TViewModel : ViewModelBase;

        void GoBack();

        event Action? CurrentViewChanged;
        event EventHandler<ViewModelBase>? WindowRequested;
    }
}
