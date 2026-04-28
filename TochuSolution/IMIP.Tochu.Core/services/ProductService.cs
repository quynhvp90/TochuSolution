using IMIP.Tochu.Core.Interfaces;
using IMIP.Tochu.Core.Mappers;
using IMIP.Tochu.Core.Models;
using IMIP.Tochu.Domain.interfaces;

namespace IMIP.Tochu.Core.Services
{
    public class ProductService : IProductService
    {
        private readonly IVI_ProductRepository _productRepository;
        public ProductService(IVI_ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<VI_Product_Model>> GetProductsAsync(string keyword = "")
        {
            var products = await _productRepository.GetByProductAsync(keyword);
            return products.Select(p => p.MapToVI_Product()).ToList();
        }
    }
}
