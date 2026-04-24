using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.configurations
{
    public class SI_SEINOUMSTConfiguration : IEntityTypeConfiguration<SI_SEINOUMST>
    {
        public void Configure(EntityTypeBuilder<SI_SEINOUMST> builder)
        {
            builder.ToTable("SI_SEINOUMST", "dbo");

            // Composite Primary Key
            builder.HasKey(x => new { x.PRODUCT, x.NOUSCD, x.NUM });

            // Columns
            builder.Property(x => x.PRODUCT)
                .HasMaxLength(64)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NOUSCD)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NUM)
                .IsRequired();

            builder.Property(x => x.MIN)
                .HasPrecision(5, 2);

            builder.Property(x => x.MAX)
                .HasPrecision(5, 2);
        }
    }
}
