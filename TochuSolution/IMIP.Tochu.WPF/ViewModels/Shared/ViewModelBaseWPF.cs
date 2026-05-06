using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Helpers;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.Views.Windows;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels.Shared
{
    public class ViewModelBaseWPF : ViewModelBase
    {
        public INavigationService _navigation;
        protected readonly IAppDataContext _appDataContext;
        public string BranchCode
        {
            get => _appDataContext.BranchCode;
            set { _appDataContext.BranchCode = value; }
        }
        public ICommand Logout { get; }
        public ICommand Back { get; }
        public ViewModelBaseWPF(INavigationService navigation, IAppDataContext appDataContext)
        {
            _navigation = navigation;
            _appDataContext = appDataContext;

            // Forward notify from AppDataContext → ViewModel
            if (_appDataContext is INotifyPropertyChanged notify)
            {
                notify.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == nameof(BranchCode))
                    {
                        OnPropertyChanged(nameof(BranchCode));
                    }
                };
            }

            Logout = new RelayCommand(() => LogoutApplication());
            Back = new RelayCommand(() => GoBack());
        }
        public string GetUsername()
        {
            if (_appDataContext.CurrentUser != null)
                return _appDataContext.CurrentUser.TEXT1 ?? "Default User";
            return "Default User";
        }
        public void GoBack()
        {
            _navigation.GoBack();
        }
        public void LogoutApplication()
        {
            _appDataContext.SetCurrentUser(null);
            SecureStorage.Remove();
            _navigation.OpenWindow<LoginWindow, LoginViewModel>();
            // close all windows except the login window
            foreach (var window in System.Windows.Application.Current.Windows)
            {
                if (window is not LoginWindow)
                {
                    ((System.Windows.Window)window).Close();
                }
            }
        }
    }
}
