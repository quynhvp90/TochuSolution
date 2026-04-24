using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using IMIP.Tochu.Infrastructure.Repositories;
using IMIP.Tochu.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using Unity;
using Unity.Lifetime;

namespace IMIP.Tochu.Infrastructure
{
    public static class InfrastructureDependencyInjection
    {
        public static IServiceCollection AddInfrastructureDI(this IServiceCollection services)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            // 🔥 DbContext (Scoped là chuẩn)
            services.AddDbContext<TochuDBContext>(options =>
                options.UseSqlServer(connectionString));

            // 🔥 DbContext Factory (tương đương RegisterFactory)
            services.AddPooledDbContextFactory<TochuDBContext>(options =>
                options.UseSqlServer(connectionString));

            // 🔥 UnitOfWork
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            // 🔥 Repositories (Scoped)
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IProductRepository, SI_MEMORepository>();
            services.AddScoped<ISICodemstRepository, SI_SEINOUDATARepository>();
            services.AddScoped<ISISeinoumstRepository, SI_SEINOUMSTRepository>();
            services.AddScoped<ICommentRepository, CommentRepository>();

            // 🔥 Logging
            services.AddTransient<ILogRepository, LogRepository>();

            return services;
        }
        public static async Task InitializeDatabase()
        {
            try
            {
                var connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

                var optionsBuilder = new DbContextOptionsBuilder<TochuDBContext>();
                optionsBuilder.UseSqlServer(connectionString);
                using var context = new TochuDBContext(optionsBuilder.Options);
                    
                context.Database.Migrate(); // apply migration
                await DbSeeder.SeedAsync(context);
                AppLogger.Info("Database migrated successfully.");
            }
            catch (Exception ex)
            {
                AppLogger.Error($"Database migration failed: {ex.Message}");
                throw;
            }
        }
    }
}
