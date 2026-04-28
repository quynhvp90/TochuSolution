using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface IProductService
    {
        Task<List<VI_Product_Model>> GetProductsAsync(string keyword = "");
    }
}
