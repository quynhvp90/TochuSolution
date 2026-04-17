using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<Domain.Entities.User>, IUserRepository
    {
        public UserRepository(TochuDBContext context) : base(context)
        {
        }

        public async Task<User?> GetByUserName(string userName)
        {
            var user = await _context.Users.Where(u => u.Name == userName).FirstOrDefaultAsync();
            return user;
        }
    }
}
