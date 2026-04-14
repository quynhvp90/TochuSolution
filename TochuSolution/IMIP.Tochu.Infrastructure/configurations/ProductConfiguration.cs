using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            // Table
            builder.ToTable("Product");

            // Primary Key
            builder.HasKey(p => p.Id);

            // Identity
            builder.Property(p => p.Id)
                   .ValueGeneratedOnAdd();

            // Required fields
            builder.Property(e => e.ProductId).IsRequired();
            builder.Property(e => e.OrderNumber).IsRequired();
            builder.Property(e => e.OrderDate).IsRequired();
            builder.Property(e => e.DeliveryDate).IsRequired();
            builder.Property(e => e.PartNumber).IsRequired();
            builder.Property(e => e.OrderQuantity).IsRequired();
            builder.Property(e => e.LotNumber).IsRequired();
            builder.Property(e => e.PerformanceTable).IsRequired();
            builder.Property(e => e.Insured).IsRequired();
            builder.Property(e => e.PrintingDate).IsRequired();
            builder.Property(e => e.Printing).IsRequired();

            // String length
            builder.Property(e => e.CustomerName).HasMaxLength(200);
            builder.Property(e => e.ProductName).HasMaxLength(200);
            builder.Property(e => e.Unit).HasMaxLength(50);
            builder.Property(e => e.PackagingCD).HasMaxLength(50);
            builder.Property(e => e.PackagingName).HasMaxLength(200);
            builder.Property(e => e.PerformanceM).HasMaxLength(50);
            builder.Property(e => e.ForCustomers).HasMaxLength(200);
            builder.Property(e => e.Comment).IsRequired(false).HasMaxLength(1000);

            // Decimal fields (EF Core 8 chuẩn)
            builder.Property(e => e.ResinContent).HasPrecision(18, 2);
            builder.Property(e => e.TransverseRuptureStrengthX).HasPrecision(18, 2);
            builder.Property(e => e.TransverseRuptureStrengthR).HasPrecision(18, 2);
            builder.Property(e => e.StickyPoint).HasPrecision(18, 2);
            builder.Property(e => e.AFS_FN).HasPrecision(18, 2);
            builder.Property(e => e.m14).HasPrecision(18, 2);
            builder.Property(e => e.m18_5).HasPrecision(18, 2);
            builder.Property(e => e.m26).HasPrecision(18, 2);
            builder.Property(e => e.m36).HasPrecision(18, 2);
            builder.Property(e => e.m50).HasPrecision(18, 2);
            builder.Property(e => e.m70).HasPrecision(18, 2);
            builder.Property(e => e.m100).HasPrecision(18, 2);
            builder.Property(e => e.m140).HasPrecision(18, 2);
            builder.Property(e => e.m200).HasPrecision(18, 2);
            builder.Property(e => e.m280).HasPrecision(18, 2);
            builder.Property(e => e.mPAN).HasPrecision(18, 2);
            builder.Property(e => e.AF_FN).HasPrecision(18, 2);
            builder.HasOne(p => p.ProductMesh)
                   .WithOne(m => m.Product)
                   .HasForeignKey<ProductMesh>(m => m.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);
            // DateTime
            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedAt)
                   .IsRequired(false);

            // Indexs
            builder.HasIndex(o => o.CreatedAt)
                   .HasDatabaseName("IX_Product_CreatedAt");

            builder.HasIndex(o => o.ProductName)
                   .HasDatabaseName("IX_Product_ProductName");

            builder.HasIndex(o => o.CustomerName)
                   .HasDatabaseName("IX_Product_CustomerName");

            builder.HasIndex(e => new { e.ProductName, e.CustomerName })
                   .HasDatabaseName("IX_Product_ProductName_CustomerName");
        }
    }
}