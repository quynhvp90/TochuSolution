using IMIP.Tochu.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetUsers();
        Task<(List<UserModel> Actives, List<UserModel> Inactives)> GetUsersAsync();
        Task<UserModel> UpdateField(Guid id, string field, object value);
        Task<UserModel> Create(UserModel user);
        Task<UserModel> Update(UserModel user);
    }
}
