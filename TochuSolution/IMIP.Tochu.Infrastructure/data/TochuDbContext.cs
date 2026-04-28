using IMIP.Tochu.Domain.entities;
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

        // Entities
        public DbSet<T0000MS_Item_RCS> T0000MS_Item_RCSs { get; set; }
        public DbSet<T0000RR_Juchuu_RCS> T0000RR_Juchuu_RCSs { get; set; }
        public DbSet<SI_CODEMST> SI_CODEMSTs { get; set; }
        public DbSet<SI_MEMO> SI_MEMOs { get; set; }
        public DbSet<SI_SEINOUDATA> SI_SEINOUDATAs { get; set; }
        public DbSet<SI_SEINOUMST> SI_SEINOUMSTs { get; set; }
        public DbSet<SI_TANTOU> SI_TANTOUs { get; set; }
        // Views
        public DbSet<VI_Product> VI_Products { get; set; }
        public DbSet<VI_SeinouMst> VI_SeinouMsts { get; set; }
        public DbSet<VI_SeinouMstSE> VI_SeinouMstSEs { get; set; }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // 🔥 Load automatic configuration
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TochuDBContext).Assembly);
            // await DbSeeder.SeedAsync(this);

        }
    }
}