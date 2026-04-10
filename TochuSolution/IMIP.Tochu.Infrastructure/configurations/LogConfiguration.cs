using IMIP.Tochu.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace IMIP.Tochu.Infrastructure.Configurations
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            // Table
            builder.ToTable("Log");

            // Primary Key
            builder.HasKey(e => e.Id);

            // Id - Identity
            builder.Property(e => e.Id)
                   .ValueGeneratedOnAdd();

            // Message
            builder.Property(e => e.Message)
                   .IsRequired()
                   .HasMaxLength(1000);

            // Level
            builder.Property(e => e.Level)
                   .IsRequired()
                   .HasMaxLength(50);

            // CreatedAt
            builder.Property(e => e.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            // Source
            builder.Property(e => e.Source)
                   .HasMaxLength(4000);

            // StackTrace
            builder.Property(e => e.StackTrace)
                   .HasMaxLength(4000);

            // UserName
            builder.Property(e => e.UserName)
                   .HasMaxLength(200);
        }
    }
}