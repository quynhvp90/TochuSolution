using IMIP.Tochu.Application.Interfaces;
using IMIP.Tochu.Application.Mappers;
using IMIP.Tochu.Application.Models;
using IMIP.Tochu.Application.Models.Paging;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Shared.Enums;
using IMIP.Tochu.Shared.Helpers;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProductService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _productRepository = _unitOfWork.Products;
        }

        public async Task<ProductModel> GetByIdAsync(Guid id)
        {
            var product = await _productRepository.GetByIdAsync(id);
            return product.Mapping();
        }

        public void GetProductChild(ProductModel product)
        {
            var listChilds = new List<ProductChildModel>();

            int childCount = 1;
            int size = GlobalHelper.GetSize(product.PackagingName);
            childCount = (int)Math.Ceiling((double)product.OrderQuantity / size);
            for (int i = 1; i <= childCount; i++)
            {
                var child = new ProductChildModel
                {
                    Id = product.Id,
                    CreatedAt = product.CreatedAt,
                    UpdatedAt = product.UpdatedAt,
                    ProductId = product.ProductId,
                    OrderNumber = product.OrderNumber,
                    Number = i,
                    LotNumber = product.LotNumber,
                    ManufacturingDate = DateTime.Now,
                    Weight = (size * i) <= product.OrderQuantity ? size : (product.OrderQuantity - size * (i - 1)),
                    Unit = product.Unit,
                    PackingCD = product.PackagingCD,
                    PackingName = product.PackagingName,
                    ProductName = product.ProductName
                };
                listChilds.Add(child);
            }
            product.Childrens = listChilds;
        }

        public List<ProductModel> GetProductChilds(List<ProductModel> products)
        {
            
            if (products != null && products.Count > 0)
            {
                foreach (var product in products)
                {
                    GetProductChild(product);
                }
            }

            return products;
        }

        public async Task<PagedResult<ProductModel>> SearchProductAsync(ProductSearchModel search)
        {
            var products = _unitOfWork.Products.Query();
            // check search fields DeliveryDate, CustomerName, PartNumber, ProductName, PerformanceTable, OrderDateFrom, OrderDateTo
            if (search.DeliveryDate.HasValue)
            {
                // check search.DeliveryDate is beetween DeliveryDate 00:00:00 and DeliveryDate 23:59:59
                products = products.Where(a => a.DeliveryDate >= search.DeliveryDate.Value.Date && a.DeliveryDate < search.DeliveryDate.Value.Date.AddDays(1));
            }
            // check order da       te is beetween OrderDateFrom and OrderDateTo and check if OrderDateFrom and OrderDateTo is not null
            if (search.OrderDateFrom.HasValue && search.OrderDateTo.HasValue)
            {
                products = products.Where(a => a.OrderDate >= search.OrderDateFrom.Value.Date && a.OrderDate < search.OrderDateTo.Value.Date.AddDays(1));
            }
            if (!string.IsNullOrEmpty(search.CustomerName))
            {
                products = products.Where(a => a.CustomerName.StartsWith(search.CustomerName));
            }
            if (search.PartNumber != null)
            {
                products = products.Where(a => a.PartNumber == search.PartNumber);
            }
            if (!string.IsNullOrEmpty(search.ProductName))
            {
                products = products.Where(a => a.ProductName.StartsWith(search.ProductName));
            }
            if (search.PerformanceTable.HasValue && search.PerformanceTable != PerformanceTable.All)
            {
                products = products.Where(a => a.PerformanceTable == search.PerformanceTable.Value);
            }
            // orderBy
            if (GlobalHelper.CheckFieldName<Product>(search.SortField)) { 
                // order by search.SortField
                products = products.OrderByField(search.SortField, search.SortDesc);
            } else
            {
                products = products.OrderBy(x => x.CreatedAt);
            }
            var count = await products.CountAsync();
            var data = await products.Skip((search.PageIndex - 1) * search.PageSize)
                .Take(search.PageSize)
                .Select(x => new ProductModel()
                {
                    Id = x.Id,
                    ProductId = x.ProductId,
                    OrderDate = x.OrderDate,
                    OrderNumber = x.OrderNumber,
                    ProductName = x.ProductName,
                    DeliveryDate = x.DeliveryDate,
                    OrderQuantity = x.OrderQuantity,
                    CustomerName    = x.CustomerName,
                    PartNumber = x.PartNumber,
                    Unit = x.Unit,
                    PackagingCD = x.PackagingCD,
                    PackagingName = x.PackagingName,    
                    LotNumber = x.LotNumber,
                    PerformanceM = x.PerformanceM,
                    PerformanceTable = x.PerformanceTable,
                    ForCustomers    = x.ForCustomers,
                    Insured = x.Insured,
                    Active = x.Active,
                    PrintingDate = x.PrintingDate,
                    Printing = x.Printing,
                    ResinContent = x.ResinContent,
                    TransverseRuptureStrengthR = x.TransverseRuptureStrengthR,
                    TransverseRuptureStrengthX = x.TransverseRuptureStrengthX,
                    StickyPoint = x.StickyPoint,
                    AFS_FN = x.AFS_FN,
                    CreatedAt = x.CreatedAt
                })
                .ToListAsync();
            return new PagedResult<ProductModel>() {
               Items = data.ToList(),
               TotalCount = count,
               PageSize = search.PageSize,
               PageIndex = search.PageIndex,
            };
        }

        public async Task UpdateProduct(ProductModel product)
        {
            var productEntity = await _productRepository.GetByIdAsync(product.Id);
            if (productEntity != null)
            {
                productEntity.UpdateMapping(product);
                _productRepository.Update(productEntity);
                await _unitOfWork.CommitAsync();
            }
        }

        public async Task<ProductModel> UpdateField(Guid id, string field, object value)
        {
            var product = await _productRepository.GetByIdAsync(id);
            if (product == null) return null;
            var prop = typeof(Product).GetProperty(field);
            if (prop == null) return null;
            prop.SetValue(product, value);
            _productRepository.Update(product);
            await _unitOfWork.CommitAsync();
            return product.Mapping();
        }
    }
}
