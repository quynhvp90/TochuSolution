using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class ProductMeshConfiguration : IEntityTypeConfiguration<ProductMesh>
    {
        public void Configure(EntityTypeBuilder<ProductMesh> builder)
        {
            builder.ToTable("ProductMesh");

            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // String
            builder.Property(e => e.ProductName)
                   .HasMaxLength(200);

            // Decimal (EF Core 8 chuẩn)
            builder.Property(e => e.ResinContextMin).HasPrecision(18, 2);
            builder.Property(e => e.ResinContextMax).HasPrecision(18, 2);
            builder.Property(e => e.StrengthXMin).HasPrecision(18, 2);
            builder.Property(e => e.StrengthXMax).HasPrecision(18, 2);
            builder.Property(e => e.StrengthRMin).HasPrecision(18, 2);
            builder.Property(e => e.StrengthRMax).HasPrecision(18, 2);
            builder.Property(e => e.StickyPointMin).HasPrecision(18, 2);
            builder.Property(e => e.StickyPointMax).HasPrecision(18, 2);

            builder.Property(e => e.M14Min).HasPrecision(18, 2);
            builder.Property(e => e.M14Max).HasPrecision(18, 2);
            builder.Property(e => e.M18_5Min).HasPrecision(18, 2);
            builder.Property(e => e.M18_5Max).HasPrecision(18, 2);
            builder.Property(e => e.M26Min).HasPrecision(18, 2);
            builder.Property(e => e.M26Max).HasPrecision(18, 2);
            builder.Property(e => e.M36Min).HasPrecision(18, 2);
            builder.Property(e => e.M36Max).HasPrecision(18, 2);
            builder.Property(e => e.M50Min).HasPrecision(18, 2);
            builder.Property(e => e.M50Max).HasPrecision(18, 2);
            builder.Property(e => e.M70Min).HasPrecision(18, 2);
            builder.Property(e => e.M70Max).HasPrecision(18, 2);
            builder.Property(e => e.M100Min).HasPrecision(18, 2);
            builder.Property(e => e.M100Max).HasPrecision(18, 2);
            builder.Property(e => e.M140Min).HasPrecision(18, 2);
            builder.Property(e => e.M140Max).HasPrecision(18, 2);
            builder.Property(e => e.M200Min).HasPrecision(18, 2);
            builder.Property(e => e.M200Max).HasPrecision(18, 2);
            builder.Property(e => e.M280Min).HasPrecision(18, 2);
            builder.Property(e => e.M280Max).HasPrecision(18, 2);
            builder.Property(e => e.MPanMin).HasPrecision(18, 2);
            builder.Property(e => e.MPanMax).HasPrecision(18, 2);

            // Date
            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedAt)
                   .IsRequired(false);

            // 🔥 One-to-One relationship (QUAN TRỌNG)
            builder.HasOne(e => e.Product)
                   .WithOne(p => p.ProductMesh)
                   .HasForeignKey<ProductMesh>(e => e.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Đảm bảo 1-1 thật sự
            builder.HasIndex(e => e.ProductId)
                   .IsUnique();
        }
    }
}