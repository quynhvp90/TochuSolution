using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMIP.Tochu.WPF.Navigation
{
    public interface INavigationService
    {
        ViewModelBaseWPF? CurrentView { get; }
        bool CanGoBack { get; }

        void NavigateTo<TViewModel>() where TViewModel : ViewModelBaseWPF;
        void NavigateTo<TViewModel>(Action<TViewModel> configure)
            where TViewModel : ViewModelBaseWPF;

        // OPEN WINDOW
        void OpenWindow<TWindow, TViewModel>(
            Action<TWindow>? configureWindow = null,
            Action<TViewModel>? configureVm = null)
            where TWindow : Window
            where TViewModel : ViewModelBaseWPF;

        bool? OpenDialog<TWindow, TViewModel>(
            Action<TWindow>? configureWindow = null,
            Action<TViewModel>? configureVm = null)
            where TWindow : Window
            where TViewModel : ViewModelBaseWPF;

        void GoBack();

        event Action? CurrentViewChanged;
        event EventHandler<ViewModelBaseWPF>? WindowRequested;
    }
}
