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
    public class T0000MS_Item_RCSConfiguration : IEntityTypeConfiguration<T0000MS_Item_RCS>
    {
        public void Configure(EntityTypeBuilder<T0000MS_Item_RCS> builder)
        {
            // Table name
            builder.ToTable("T0000MS_Item_RCS");

            // Primary key
            builder.HasKey(x => x.UserHinban);

            // Columns
            builder.Property(x => x.UserHinban)
                .HasColumnName("UserHinban")
                .HasMaxLength(64)
                .IsRequired()
                .IsUnicode(false);

            builder.Property(x => x.UserHinmei)
                .HasColumnName("UserHinmei")
                .HasMaxLength(64)
                .IsUnicode(false);
        }
    }
}
