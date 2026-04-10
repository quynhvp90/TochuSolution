using IMIP.Tochu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface IProductMeshRepository : IRepository<ProductMesh>
    {
        Task<ProductMesh> GetByProductId(Guid ProductId);
    }
}
