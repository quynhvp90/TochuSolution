using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using IMIP.Tochu.Infrastructure.repositories;
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
            services.AddScoped<ISI_CODEMSTRepository, SI_CODEMSTRepository>();
            services.AddScoped<ISI_MEMORepository, SI_MEMORepository>();
            services.AddScoped<ISI_SEINOUDATARepository, SI_SEINOUDATARepository>();
            services.AddScoped<ISI_SEINOUMSTRepository, SI_SEINOUMSTRepository>();
            services.AddScoped<ISI_TANTOURepository, SI_TANTOURepository>();
            services.AddScoped<IT0000MS_Item_RCSRepository, T0000MS_Item_RCSRepository>();
            services.AddScoped<IT0000RR_Juchuu_RCSRepository, T0000RR_Juchuu_RCSRepository>();
            // 🔥 Repositories Views
            services.AddScoped<IVI_ProductRepository, VI_ProductRepository>();
            services.AddScoped<IVI_SeinouMstRepository, VI_SeinouMstRepository>();
            services.AddScoped<IVI_SeinouMstSERepository, VI_SeinouMstSERepository>();

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
