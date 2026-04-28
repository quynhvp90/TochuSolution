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
    public class VI_SeinouMstSEConfiguration : IEntityTypeConfiguration<VI_SeinouMstSE>
    {
        public void Configure(EntityTypeBuilder<VI_SeinouMstSE> builder)
        {
            builder.HasNoKey();
            builder.ToView("VI_SEINOUMSTSE");

            builder.Property(x => x.PRODUCT).HasColumnName("PRODUCT");
            builder.Property(x => x.NOUSCD).HasColumnName("NOUSCD");
        }
    }
}
