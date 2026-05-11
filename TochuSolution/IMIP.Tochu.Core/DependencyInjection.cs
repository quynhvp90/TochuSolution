using IMIP.Tochu.Core.interfaces;
using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.LogServices;
using IMIP.Tochu.Core.services;
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
            services.AddTransient<ITANTOUService, TANTOUService>();
            services.AddTransient<IJuchuuRCSService, JuchuuRCSService>();
            services.AddTransient<ISENINOUDATAService, SENINOUDATAService>();
            services.AddTransient<IVI_ProductService, VI_ProductService>();
            services.AddTransient<IVI_SeinouMstSEService, VI_SeinouMstSEService>();
            services.AddTransient<IVI_SeinouMstService, VI_SeinouMstService>();

            // Singleton tương đương ContainerControlledLifetimeManager
            services.AddSingleton<ILogQueue, LogQueueService>();
            services.AddSingleton<LogWorker>();


            return services;
        }
    }
}
