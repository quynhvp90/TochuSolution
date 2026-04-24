using IMIP.Tochu.Domain.Entities;
using IMIP.Tochu.Domain.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IMIP.Tochu.Domain.Interfaces
{
    public interface IUnitOfWork
    {

        ISI_CODEMSTRepository SI_CODEMST { get; }
        ISI_MEMORepository SI_MEMO { get; }
        ISI_SEINOUDATARepository SI_SEINOUDATA { get; }
        ISI_SEINOUMSTRepository SI_SEINOUMST { get; }
        ISI_TANTOURepository SI_TANTOU { get; }
        IT0000MS_Item_RCSRepository T0000MS_Item_RCS { get; }
        IT0000RR_Juchuu_RCSRepository T0000RR_Juchuu_RCS { get; }
        // ⭐ ONLY for transaction-heavy operations
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
