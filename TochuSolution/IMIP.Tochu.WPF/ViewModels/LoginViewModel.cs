using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Shared;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Helpers;
using IMIP.Tochu.WPF.ViewModels.Shared;
using IMIP.Tochu.WPF.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace IMIP.Tochu.WPF.ViewModels
{
    public class LoginViewModel : ViewModelBaseWPF
    {
        private readonly IAuthService _auth;
        private readonly IAppDataContext _appDataContext;
        private readonly ILocalizationService _loc;

        public string Username { get; set; } = "admin";
        public string Password { get; set; }


        public LoginViewModel(IAuthService auth, INavigationService navigation, IAppDataContext appDataContext, ILocalizationService loc) : base(navigation, appDataContext)
        {
            _auth = auth;
            _appDataContext = appDataContext;
            _loc = loc;
            _appDataContext.SetCurrentUser(null);
        }

        public async Task Login(string password)
        {
            var user = await _auth.Login(Username, password);
            if (user != null)
            {
                _appDataContext.SetCurrentUser(user);
                string token = Helper.CreateTokenFromUser(user);
                SecureStorage.Save(token);
                // Open MainWindow
                _navigation.OpenWindow<MainWindow, MainWindowViewModel>();
                // Close LoginWindow
                CloseLoginWindow();
            } else
            {
                // show message box error
                MessageBoxManager.ShowError(_loc.Get("Login_Error_InvalidCredentials"), _loc.Get("Login_Error_Title"));
            }
        }

        private void CloseLoginWindow()
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (w is LoginWindow)
                {
                    w.Close();
                    break;
                }
            }
        }
    }
}
