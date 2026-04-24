using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Infrastructure.Data;
using IMIP.Tochu.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.repositories
{
    public class T0000RR_Juchuu_RCSRepository : GenericRepository<T0000RR_Juchuu_RCS>, IT0000RR_Juchuu_RCSRepository
    {
        public T0000RR_Juchuu_RCSRepository(TochuDBContext dBContext) : base(dBContext) { }
    }
}
