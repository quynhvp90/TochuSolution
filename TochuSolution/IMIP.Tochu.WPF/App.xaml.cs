using IMIP.Tochu.Infrastructure;
using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using IMIP.Tochu.UI.ViewModels;
using IMIP.Tochu.WPF.Helpers;
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
            var container = new UnityContainer();
            container.RegisterInfrastructure();
            await DependencyInjection.InitializeDatabase();
            ConfigureServices(services);
           
            _serviceProvider = services.BuildServiceProvider();

            // Navigate trang mặc định
            var nav = _serviceProvider.GetRequiredService<INavigationService>();
            nav.NavigateTo<MainViewModel>();

            // Start MainWindow
            var mainVM = _serviceProvider.GetRequiredService<MainViewModel>();
            var window = new MainWindow(mainVM, nav);
            window.Show();
        }
        private void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            // --- Navigation ---
            services.AddSingleton<INavigationService, NavigationService>();

            // Factory để NavigationService resolve ViewModel từ DI
            services.AddSingleton<Func<Type, ViewModelBase>>(sp =>
                type => (ViewModelBase)sp.GetRequiredService(type));

            // --- ViewModels ---
            services.AddSingleton<MainViewModel>();   // Singleton
            services.AddTransient<SearchViewModel>(); // Transient
            services.AddTransient<MasterViewModel>(); // Transient
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _serviceProvider.Dispose();
            base.OnExit(e);
        }
    }
    

}
