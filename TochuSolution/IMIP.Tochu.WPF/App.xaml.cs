using IMIP.Tochu.Core;
using IMIP.Tochu.Infrastructure;
using IMIP.Tochu.UI;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using IMIP.Tochu.WPF.ViewModels;
using IMIP.Tochu.WPF.Helpers;
using Infragistics.Controls.Charts;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Reflection;
using System.Windows;
using Unity;

namespace IMIP.Tochu.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private ServiceProvider _serviceProvider = null!;
        private IUnityContainer _container = null!;
        protected async override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var services = new ServiceCollection();
            await InfrastructureDependencyInjection.InitializeDatabase();
            ConfigureServices(services);
           
            _serviceProvider = services.BuildServiceProvider();

            // Navigate trang mặc định
            var nav = _serviceProvider.GetRequiredService<INavigationService>();
            nav.NavigateTo<MainViewModel>();

            // Start MainWindow
            var mainVM = _serviceProvider.GetRequiredService<MainWindowViewModel>();
            var window = new MainWindow(
                mainVM    
            );
            window.Show();
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
