using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System.Configuration;

namespace IMIP.Tochu.Infrastructure.data
{
    public class TochuDbContextFactory : IDesignTimeDbContextFactory<TochuDBContext>
    {
        public TochuDBContext CreateDbContext(string[] args)
        {
            var connectionString = ConfigurationManager
                .ConnectionStrings["DefaultConnection"]
                .ConnectionString;

            var optionsBuilder = new DbContextOptionsBuilder<TochuDBContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new TochuDBContext(optionsBuilder.Options);
        }
    }
}
