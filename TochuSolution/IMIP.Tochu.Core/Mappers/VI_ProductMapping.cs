using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Mappers
{
    public static class VI_ProductMapping
    {
        public static VI_Product_Model MapToVI_Product(this VI_Product product)
        {
            return new VI_Product_Model
            {
                UserHinban = product.UserHinban,
                UserHinmei = product.UserHinmei,
                NOUSCD = product.NOUSCD
            };
        }
    }
}
