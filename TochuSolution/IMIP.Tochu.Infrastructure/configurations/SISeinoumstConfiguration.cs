using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class SISeinoumstConfiguration : IEntityTypeConfiguration<SI_Seinoumst>
    {
        public void Configure(EntityTypeBuilder<SI_Seinoumst> builder)
        {
            // Table
            builder.ToTable("SI_Seinoumst");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Identity
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // String
            builder.Property(e => e.Product)
                   .HasMaxLength(200);

            builder.Property(e => e.CustomerName)
                   .HasMaxLength(200);

            // Required
            builder.Property(e => e.Min)
                   .IsRequired();

            builder.Property(e => e.Max)
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