using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using IMIP.Tochu.Infrastructure.Repositories;
using IMIP.Tochu.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Configuration;
using Unity;
using Unity.Lifetime;

namespace IMIP.Tochu.Infrastructure
{
    public static class DependencyInjection
    {
        public static IUnityContainer RegisterInfrastructure(this IUnityContainer container)
        {

            // ── DbContext ───────────────────────────────
            container.RegisterFactory<TochuDBContext>(c =>
            {
                var connectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                var optionsBuilder = new DbContextOptionsBuilder<TochuDBContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new TochuDBContext(optionsBuilder.Options);

            }, new HierarchicalLifetimeManager());

            container.RegisterFactory<IDbContextFactory<TochuDBContext>>(c =>
            {
                var connectionString = ConfigurationManager
                    .ConnectionStrings["DefaultConnection"]
                    .ConnectionString;

                var optionsBuilder = new DbContextOptionsBuilder<TochuDBContext>();
                optionsBuilder.UseSqlServer(connectionString);

                return new PooledDbContextFactory<TochuDBContext>(optionsBuilder.Options);
            });
            // ── UnitOfWork ─────────────────────────────
            container.RegisterType<IUnitOfWork, UnitOfWork>(new HierarchicalLifetimeManager());

            // ── Repositories ───────────────────────────
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IProductRepository, ProductRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISICodemstRepository, SICodemstRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ISISeinoumstRepository, SISeinoumstRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());

            // Logging
            container.RegisterType<ILogRepository, LogRepository>(new TransientLifetimeManager());

            return container;
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
