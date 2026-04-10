using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class ProductMeshRepository : GenericRepository<ProductMesh>, IProductMeshRepository
    {
        public ProductMeshRepository(TochuDBContext context) : base(context)
        {
        }

        public Task<ProductMesh> GetByProductId(Guid ProductId)
        {
            throw new NotImplementedException();
        }
    }
}
