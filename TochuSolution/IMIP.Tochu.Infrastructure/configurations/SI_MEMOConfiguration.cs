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
    public class SI_MEMOConfiguration : IEntityTypeConfiguration<SI_MEMO>
    {
        public void Configure(EntityTypeBuilder<SI_MEMO> builder)
        {
            builder.ToTable("SI_MEMO", "dbo");

            // Composite primary key
            builder.HasKey(x => new { x.JIGYOUSHO, x.NUM });

            // Columns
            builder.Property(x => x.JIGYOUSHO)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NUM)
                .IsRequired();

            builder.Property(x => x.MEMO)
                .HasMaxLength(256);
        }
    }
}
