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
    public class SI_CODEMSTConfiguration : IEntityTypeConfiguration<SI_CODEMST>
    {
        public void Configure(EntityTypeBuilder<SI_CODEMST> builder)
        {
            builder.ToTable("SI_CODEMST", "dbo");

            // Composite Primary Key
            builder.HasKey(x => new { x.KBN, x.ID });

            // Columns
            builder.Property(x => x.KBN)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.ID)
                .IsRequired();

            builder.Property(x => x.NM)
                .HasMaxLength(64)
                .IsRequired();

            builder.Property(x => x.ENUM)
                .HasDefaultValue(0);

            builder.Property(x => x.EYOBI)
                .HasMaxLength(32)
                .IsUnicode(false);
        }
    }
}
