using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.LogServices;
using IMIP.Tochu.Core.Services;
using Microsoft.Extensions.DependencyInjection;

namespace IMIP.Tochu.Core
{
    public static class CoreDependencyInjection
    {
        public static IServiceCollection AddCoreDI(this IServiceCollection services)
        {
            services.AddSingleton<IAuthService, AuthService>();
            services.AddTransient<IDbLogger, LoggerService>();
            services.AddTransient<IProductService, ProductService>();

            // Singleton tương đương ContainerControlledLifetimeManager
            services.AddSingleton<ILogQueue, LogQueueService>();
            services.AddSingleton<LogWorker>();


            return services;
        }
    }
}
