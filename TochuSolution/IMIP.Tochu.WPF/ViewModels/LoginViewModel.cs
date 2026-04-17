using IMIP.Tochu.Core.Interfaces;
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

        public string Username { get; set; } = "admin";
        public string Password { get; set; }


        public LoginViewModel(IAuthService auth, INavigationService navigation) : base(navigation)
        {
            _auth = auth;
            AppSession.CurrentUser = null;
        }

        public async Task Login(string password)
        {
            var user = await _auth.Login(Username, password);
            if (user != null)
            {
                AppSession.CurrentUser = user;
                string token = Helper.CreateTokenFromUser(user);
                SecureStorage.Save(token);
                // Open MainWindow
                _navigation.OpenWindow<MainWindow, MainWindowViewModel>();
                // Close LoginWindow
                CloseLoginWindow();
            } else
            {
                // show message box error
                MessageBoxManager.ShowError("Invalid username or password", "Login failed");
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
