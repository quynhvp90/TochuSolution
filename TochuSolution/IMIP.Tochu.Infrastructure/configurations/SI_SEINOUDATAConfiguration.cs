using IMIP.Tochu.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.configurations
{
    public class SI_SEINOUDATAConfiguration : IEntityTypeConfiguration<SI_SEINOUDATA>
    {
        public void Configure(EntityTypeBuilder<SI_SEINOUDATA> builder)
        {
            builder.ToTable("SI_SEINOUDATA", "dbo");

            // Composite PK
            builder.HasKey(x => new { x.JUCHUUNO, x.NUM });

            builder.Property(x => x.JUCHUUNO).IsRequired();
            builder.Property(x => x.NUM).IsRequired();

            // strings
            builder.Property(x => x.LOTNO).HasMaxLength(32).IsUnicode(false);
            builder.Property(x => x.USERHINBAN).HasMaxLength(64).IsUnicode(false);

            builder.Property(x => x.NOUSCD)
                .HasMaxLength(12)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NOUSSNM).HasMaxLength(64);
            builder.Property(x => x.NISUGATACD).HasMaxLength(16).IsUnicode(false);

            builder.Property(x => x.SUUJP).HasMaxLength(24).IsUnicode(false);

            builder.Property(x => x.TANTOU1).HasMaxLength(32).IsUnicode(false);
            builder.Property(x => x.TANTOU2).HasMaxLength(32).IsUnicode(false);
            builder.Property(x => x.TANTOU3).HasMaxLength(32).IsUnicode(false);

            builder.Property(x => x.COMM).HasMaxLength(512);

            // decimals (5,2)
            builder.Property(x => x.T10).HasPrecision(5, 2);
            builder.Property(x => x.T20).HasPrecision(5, 2);
            builder.Property(x => x.T30).HasPrecision(5, 2);
            builder.Property(x => x.T40).HasPrecision(5, 2);
            builder.Property(x => x.T50).HasPrecision(5, 2);
            builder.Property(x => x.T60).HasPrecision(5, 2);
            builder.Property(x => x.T70).HasPrecision(5, 2);
            builder.Property(x => x.T80).HasPrecision(5, 2);
            builder.Property(x => x.T90).HasPrecision(5, 2);
            builder.Property(x => x.T100).HasPrecision(5, 2);
            builder.Property(x => x.T110).HasPrecision(5, 2);
            builder.Property(x => x.T120).HasPrecision(5, 2);
            builder.Property(x => x.T130).HasPrecision(5, 2);
            builder.Property(x => x.T140).HasPrecision(5, 2);
            builder.Property(x => x.T150).HasPrecision(5, 2);
            builder.Property(x => x.T160).HasPrecision(5, 2);

            builder.Property(x => x.MA150).HasPrecision(5, 2);
            builder.Property(x => x.MA20).HasPrecision(5, 2);
            builder.Property(x => x.MA30).HasPrecision(5, 2);

            // datetime / date
            builder.Property(x => x.UPTIME);
            builder.Property(x => x.NOUKI);

            builder.Property(x => x.PRINTDT)
                .HasDefaultValue(new DateTime(9999, 12, 31));
        }
    }
}
