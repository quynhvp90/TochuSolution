using IMIP.Tochu.Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.configurations
{
    public class SI_TANTOUConfiguration : IEntityTypeConfiguration<SI_TANTOU>
    {
        public void Configure(EntityTypeBuilder<SI_TANTOU> builder)
        {
            builder.ToTable("SI_TANTOU", "dbo");

            // Composite primary key
            builder.HasKey(x => new { x.JIGYOUSHO, x.NUM });

            // Columns
            builder.Property(x => x.JIGYOUSHO)
                .HasMaxLength(9)
                .IsUnicode(false)
                .IsRequired();

            builder.Property(x => x.NUM)
                .IsRequired();

            builder.Property(x => x.TEXT1)
                .HasMaxLength(32)
                .IsUnicode(false);
        }
    }
}
