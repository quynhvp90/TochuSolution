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
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IProductService, ProductService>();
            services.AddTransient<ISettingService, SettingService>();
            services.AddTransient<IDbLogger, LoggerService>();

            // Singleton tương đương ContainerControlledLifetimeManager
            services.AddSingleton<ILogQueue, LogQueueService>();
            services.AddSingleton<LogWorker>();

            services.AddTransient<ICommentService, CommentService>();

            return services;
        }
    }
}
