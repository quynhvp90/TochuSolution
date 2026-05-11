using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class T0000RR_Juchuu_RCSRepository : GenericRepository<T0000RR_Juchuu_RCS>, IT0000RR_Juchuu_RCSRepository
    {
        public T0000RR_Juchuu_RCSRepository(TochuDBContext dBContext) : base(dBContext) { }

        public async Task<T0000RR_Juchuu_RCS?> GetByIDAsync(int juchuuNO)
        {
            return await _context.T0000RR_Juchuu_RCSs.Where(x => x.JuchuuNO == juchuuNO).FirstOrDefaultAsync();
        }
    }
}
