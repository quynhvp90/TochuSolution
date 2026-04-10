using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("User");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Identity
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // Name
            builder.Property(e => e.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            // Email
            builder.Property(e => e.Email)
                   .IsRequired()
                   .HasMaxLength(200);

            // Password
            builder.Property(e => e.PasswordHash)
                   .IsRequired();

            // Date
            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(e => e.UpdatedAt)
                   .IsRequired(false);

            // 🔥 Index & Constraint
            builder.HasIndex(e => e.Email)
                   .IsUnique();
        }
    }
}