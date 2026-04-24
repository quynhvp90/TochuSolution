using IMIP.Tochu.Domain.entities;
using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Domain.QueryResults;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class SI_MEMORepository : GenericRepository<SI_MEMO>, ISI_MEMORepository
    {
        public SI_MEMORepository(TochuDBContext context) : base(context)
        {
        }

    }
}
