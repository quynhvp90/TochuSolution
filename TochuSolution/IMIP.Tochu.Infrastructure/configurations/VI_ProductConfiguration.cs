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
    public class VI_ProductConfiguration : IEntityTypeConfiguration<VI_Product>
    {
        public void Configure(EntityTypeBuilder<VI_Product> builder)
        {
            builder.HasNoKey();
            builder.ToView("VI_PRODUCT");
        }
    }
}