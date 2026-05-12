using IMIP.Tochu.WPF.AppData;
using IMIP.Tochu.WPF.Navigation;
using IMIP.Tochu.WPF.ViewModels;
using IMIP.Tochu.WPF.ViewModels.Shared;
using IMIP.Tochu.WPF.Views.UserControls;
using IMIP.Tochu.WPF.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    public static class ViewModelDependencyInjection
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            // --- Navigation ---
            services.AddSingleton<INavigationService, NavigationService>();
            // -- AppContext ---
            services.AddSingleton<IAppDataContext, AppDataContext>();

            // Factory để NavigationService resolve ViewModel từ DI
            services.AddSingleton<Func<Type, ViewModelBaseWPF>>(sp => type => (ViewModelBaseWPF)sp.GetRequiredService(type));
            services.AddSingleton<Func<Type, Window>>(sp => type => (Window)sp.GetRequiredService(type));

            // ViewModels
            services.AddSingleton<MainWindowViewModel>();   // Singleton
            services.AddTransient<DashboardViewModel>(); // Transient
            services.AddTransient<SearchViewModel>(); // Transient
            services.AddTransient<SearchViewModel>(); // Transient
            services.AddTransient<MasterViewModel>(); // Transient
            services.AddTransient<MasterAnalysisViewModel>(); // Transient
            services.AddTransient<RegistrationViewModel>(); // Transient
            services.AddTransient<LoginViewModel>(); // Transient
            services.AddTransient<PagingViewModel>(); // Transient
            services.AddTransient<AnalysisMasterModalViewModel>(); // Transient

            // Views
            services.AddTransient<Registration>();
            services.AddTransient<AnalysisMasterModal>();
            services.AddTransient<MainWindow>();
            services.AddTransient<Dashboard>();
            services.AddTransient<Search>();
            services.AddTransient<Master>();
            services.AddTransient<LoginWindow>();
            services.AddTransient<PagingControl>();
            return services;
        }
    }
}
