using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Helpers;
using IMIP.Tochu.WPF.Views.Windows;
using Newtonsoft.Json.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels.Shared
{
    public class ViewModelBaseWPF : ViewModelBase
    {
        public INavigationService _navigation;
        private readonly IAppDataContext _appDataContext;
        public string BranchCode { get { return _appDataContext.BranchCode; } set { _appDataContext.SetBranchCode(value); OnPropertyChanged(); } }
        public ICommand Logout { get; }
        public ViewModelBaseWPF(INavigationService navigation, IAppDataContext appDataContext = null)
        {
            _navigation = navigation;
            _appDataContext = appDataContext ?? AppDataContext.Instance;
            Logout = new RelayCommand(() => LogoutApplication());
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
