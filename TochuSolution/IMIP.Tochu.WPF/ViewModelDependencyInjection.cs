using IMIP.Tochu.UI.Base;
using IMIP.Tochu.UI.Navigation;
using IMIP.Tochu.WPF.ViewModels;
using IMIP.Tochu.WPF.Views.UserControls;
using IMIP.Tochu.WPF.Views.Windows;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace IMIP.Tochu.WPF
{
    public static class ViewModelDependencyInjection
    {
        public static IServiceCollection RegisterViewModels(this IServiceCollection services)
        {
            // --- Navigation ---
            services.AddSingleton<INavigationService, NavigationService>();

            // Factory để NavigationService resolve ViewModel từ DI
            services.AddSingleton<Func<Type, ViewModelBase>>(sp => type => (ViewModelBase)sp.GetRequiredService(type));
            services.AddSingleton<Func<Type, Window>>(sp => type => (Window)sp.GetRequiredService(type));

            // ViewModels
            services.AddSingleton<MainWindowViewModel>();   // Singleton
            services.AddTransient<MainViewModel>(); // Transient
            services.AddTransient<SearchViewModel>(); // Transient
            services.AddTransient<SearchViewModel>(); // Transient
            services.AddTransient<MasterViewModel>(); // Transient
            services.AddTransient<RegistrationViewModel>(); // Transient

            // Windows
            services.AddTransient<Registration>();
            services.AddTransient<MainWindow>();
            services.AddTransient<Main>();
            services.AddTransient<SearchView>();
            services.AddTransient<Master>();
            return services;
        }
    }
}
