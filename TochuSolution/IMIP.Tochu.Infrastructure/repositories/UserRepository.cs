using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class UserRepository : GenericRepository<Domain.Entities.User>, IUserRepository
    {
        public UserRepository(TochuDBContext context) : base(context)
        {
        }
    }
}
