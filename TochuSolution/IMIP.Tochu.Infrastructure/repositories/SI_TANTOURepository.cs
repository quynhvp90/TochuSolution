using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class SI_TANTOURepository : GenericRepository<SI_TANTOU>, ISI_TANTOURepository
    {
        public SI_TANTOURepository(TochuDBContext context) : base(context)
        {
        }

        public async Task<SI_TANTOU?> GetByUserName(string userName)
        {
            var result = await _context.SI_TANTOUs.FirstOrDefaultAsync(t => t.TEXT1 == userName);
            return result;
        }
    }
}
