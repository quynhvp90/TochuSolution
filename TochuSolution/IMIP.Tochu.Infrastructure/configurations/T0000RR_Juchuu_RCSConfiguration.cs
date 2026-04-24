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
    public class T0000RR_Juchuu_RCSConfiguration : IEntityTypeConfiguration<T0000RR_Juchuu_RCS>
    {
        public void Configure(EntityTypeBuilder<T0000RR_Juchuu_RCS> builder)
        {
            builder.ToTable("T0000RR_Juchuu_RCS");

            // Primary key
            builder.HasKey(x => x.JuchuuNO);

            builder.Property(x => x.JuchuuNO)
                .IsRequired();

            builder.Property(x => x.JuchuuDenpyouNO)
                .IsRequired();

            // string fields
            builder.Property(x => x.JuchuuKyotenCD).HasMaxLength(3).IsUnicode(false);
            builder.Property(x => x.JuchuuKyotenNM).HasMaxLength(64);

            builder.Property(x => x.ShukkaKyotenCD).HasMaxLength(12).IsUnicode(false);
            builder.Property(x => x.ShukkaBashoCD).HasMaxLength(12).IsUnicode(false);

            builder.Property(x => x.JuchuuKBN).HasMaxLength(12).IsUnicode(false);
            builder.Property(x => x.HaisouCD).HasMaxLength(12).IsUnicode(false);
            builder.Property(x => x.ChikuCD).HasMaxLength(12).IsUnicode(false);

            builder.Property(x => x.NouSCD).HasMaxLength(12).IsUnicode(false);
            builder.Property(x => x.NouSSNM).HasMaxLength(64);

            builder.Property(x => x.UserHinban).HasMaxLength(64).IsUnicode(false);
            builder.Property(x => x.UserHinmei).HasMaxLength(64);

            builder.Property(x => x.ItemCD).HasMaxLength(32).IsUnicode(false);
            builder.Property(x => x.ItemNM).HasMaxLength(64);

            builder.Property(x => x.NisugataCD).HasMaxLength(16).IsUnicode(false);
            builder.Property(x => x.UriKeitaiKBN).HasMaxLength(10).IsUnicode(false);
            builder.Property(x => x.Tekiyou1).HasMaxLength(64);

            builder.Property(x => x.TankaUnitCD).HasMaxLength(12).IsUnicode(false);

            // date fields
            builder.Property(x => x.JuchuuYMD).HasColumnType("date");
            builder.Property(x => x.Nouki).HasColumnType("date");


            // Indexes
            builder.HasIndex(x => x.JuchuuKyotenCD)
                .HasDatabaseName("IX_Juchuu_KyotenCD");

            builder.HasIndex(x => x.NouSCD)
                .HasDatabaseName("IX_NouSCD");

            builder.HasIndex(x => x.NouSSNM)
                .HasDatabaseName("IX_NouSSNM");
        }
    }
}
