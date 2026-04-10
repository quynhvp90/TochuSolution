using IMIP.Tochu.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T?> GetByIdAsync(Guid id);
        IQueryable<T> Query();
        Task<IReadOnlyList<T>> GetAllAsync();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
