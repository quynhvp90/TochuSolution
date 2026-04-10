using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class SISeinoumstRepository : GenericRepository<SI_Seinoumst>, ISISeinoumstRepository
    {
        public SISeinoumstRepository(TochuDBContext context) : base(context)
        {
        }
    }
}
