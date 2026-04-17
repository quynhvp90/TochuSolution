
using IMIP.Tochu.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User?> GetByUserName(string userName);
    }
}
