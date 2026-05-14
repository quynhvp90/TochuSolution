using IMIP.Tochu.Core;
using IMIP.Tochu.Infrastructure;
using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Helpers;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels;
using IMIP.Tochu.WPF.Views.Windows;
using Infragistics.Themes;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Globalization;
using System.Threading;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        public static IServiceProvider? Services { get; private set; }

        private ServiceProvider _serviceProvider = null!;
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            // Apply locale from App.config before UI loads
            var locale = ConfigurationManager.AppSettings["AppLocale"] ?? "en-US";
            var culture = new CultureInfo(locale);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;

            // Load Theme
            ThemeManager.ApplicationTheme = new Office2013Theme();
            var services = new ServiceCollection();
            await InfrastructureDependencyInjection.InitializeDatabase();
            ConfigureServices(services, locale);

            _serviceProvider = services.BuildServiceProvider();
            Services = _serviceProvider;

            // Navigate Default Application View
            var appDataContext = _serviceProvider.GetRequiredService<IAppDataContext>();
            var nav = _serviceProvider.GetRequiredService<INavigationService>();
            //nav.OpenWindow<MainWindow, MainWindowViewModel>();

            // check Args default
            string branchCode = e.Args.Length > 0 ? e.Args[0] : "310";
            appDataContext.BranchCode = branchCode;

            // ================= CHECK LOGIN =================
            var logined = true;

            var token = SecureStorage.Load();
            if (logined)
            {
                nav.OpenWindow<MainWindow, MainWindowViewModel>();
            } else if (!string.IsNullOrEmpty(token) && logined)
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
        private void ConfigureServices(IServiceCollection services, string locale)
        {
            services.AddLogging();
            services.AddInfrastructureDI();
            services.AddCoreDI();

            // --- ViewModels ---
            services.RegisterViewModels(locale);
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider.Dispose();
            base.OnExit(e);
        }
    }
    

}
