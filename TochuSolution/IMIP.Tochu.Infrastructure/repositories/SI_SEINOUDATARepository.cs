using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class SI_SEINOUDATARepository : GenericRepository<SI_SEINOUDATA>, ISI_SEINOUDATARepository
    {
        public SI_SEINOUDATARepository(TochuDBContext context) : base(context)
        {
        }
    }
}
