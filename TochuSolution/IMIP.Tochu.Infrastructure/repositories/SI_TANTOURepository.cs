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
    public class SI_TANTOURepository : GenericRepository<SI_TANTOU>, ISI_TANTOURepository
    {
        public SI_TANTOURepository(TochuDBContext context) : base(context)
        {
        }
    }
}
