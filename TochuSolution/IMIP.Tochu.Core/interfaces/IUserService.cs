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
        Task<List<UserModel>> GetUsersAsync();
        Task<List<UserModel>> GetUsersAsync(string keyword);
        Task<UserModel> UpdateFieldAsync(Guid id, string field, object value);
        Task<UserModel> CreateAsync(UserModel user);
        Task<UserModel> UpdateAsync(UserModel user);
    }
}
