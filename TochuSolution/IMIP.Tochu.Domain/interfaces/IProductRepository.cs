using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.QueryResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<List<InputLogicResult>> GetInputLogic(string productName);
    }
}
