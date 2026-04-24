using IMIP.Tochu.Core;
using IMIP.Tochu.Infrastructure;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Helpers;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels;
using IMIP.Tochu.WPF.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private ServiceProvider _serviceProvider = null!;
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            await InfrastructureDependencyInjection.InitializeDatabase();
            ConfigureServices(services);
           
            _serviceProvider = services.BuildServiceProvider();

            // Navigate Default Application View
            var appDataContext = _serviceProvider.GetRequiredService<IAppDataContext>();
            var nav = _serviceProvider.GetRequiredService<INavigationService>();
            nav.NavigateTo<MainViewModel>();

            // check Args default
            string branchCode = e.Args.Length > 0 ? e.Args[0] : "310";
            appDataContext.SetBranchCode(branchCode);

            // ================= CHECK LOGIN =================
            var token = SecureStorage.Load();
            if (!string.IsNullOrEmpty(token))
            { 
                var user = Helper.GetUserFromToken(token);

                if (user != null && !Helper.IsTokenExpired(token))
                {
                    appDataContext.SetCurrentUser(user);
                    var newToken = Helper.CreateTokenFromUser(user);
                    SecureStorage.Save(newToken);
                    nav.OpenWindow<MainWindow, MainWindowViewModel>();
                }
                else
                {
                    nav.OpenWindow<LoginWindow, LoginViewModel>();
                }
            } else
            {
                nav.OpenWindow<LoginWindow, LoginViewModel>();
            }

        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddInfrastructureDI();
            services.AddCoreDI();
            
            // --- ViewModels ---
            services.RegisterViewModels();
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider.Dispose();
            base.OnExit(e);
        }
    }
    

}
