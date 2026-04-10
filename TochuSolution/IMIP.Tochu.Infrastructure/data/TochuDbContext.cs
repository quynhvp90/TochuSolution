using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Data
{
    public class TochuDBContext : DbContext
    {
        public TochuDBContext(DbContextOptions<TochuDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<SI_Codemst> SI_Codemsts { get; set; }
        public DbSet<SI_Seinoumst> SI_Seinoumsts { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ProductMesh> ProductMeshes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 Load automatic configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TochuDBContext).Assembly);

        }
    }
}