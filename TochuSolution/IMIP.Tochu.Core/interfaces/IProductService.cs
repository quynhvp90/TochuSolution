using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Core.Models.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface IProductService
    {
        Task<PagedResult<ProductModel>> SearchProductAsync(ProductSearchModel? search);
        List<ProductModel> GetProductChilds(List<ProductModel> products);
        void GetProductChild(ProductModel products);
        Task<ProductModel> GetByIdAsync(Guid id);
        Task UpdateProduct(ProductModel product);
        Task<ProductModel> UpdateField(Guid id, string field, object value);
    }
}
