using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            // Table
            builder.ToTable("Comment");

            // Primary Key
            builder.HasKey(c => c.Id);

            // Id - Identity
            builder.Property(c => c.Id)
                   .ValueGeneratedOnAdd();

            // Content
            builder.Property(c => c.Content)
                   .HasMaxLength(4000);

            // CreatedAt
            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            // UpdatedAt (nullable)
            builder.Property(c => c.UpdatedAt)
                   .IsRequired(false);
        }
    }
}