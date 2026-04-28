using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Infrastructure.Data;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class T0000RR_Juchuu_RCSRepository : GenericRepository<T0000RR_Juchuu_RCS>, IT0000RR_Juchuu_RCSRepository
    {
        public T0000RR_Juchuu_RCSRepository(TochuDBContext dBContext) : base(dBContext) { }
    }
}
