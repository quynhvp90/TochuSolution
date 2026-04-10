using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class SICodemstConfiguration : IEntityTypeConfiguration<SI_Codemst>
    {
        public void Configure(EntityTypeBuilder<SI_Codemst> builder)
        {
            // Table
            builder.ToTable("SI_Codemst");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Identity
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // Fields
            builder.Property(e => e.Nm)
                   .HasMaxLength(200);

            builder.Property(e => e.Kbn)
                   .HasMaxLength(50);

            builder.Property(e => e.Eyobi)
                   .HasMaxLength(200);

            builder.Property(e => e.Num)
                   .IsRequired();

            builder.Property(e => e.Enum)
                   .IsRequired();

            // Date
            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedAt)
                   .IsRequired(false);
        }
    }
}