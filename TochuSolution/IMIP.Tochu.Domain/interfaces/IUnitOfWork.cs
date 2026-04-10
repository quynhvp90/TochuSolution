using IMIP.Tochu.Domain.Entities;
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
        IUserRepository Users { get; }
        IProductRepository Products { get; }
        ISICodemstRepository SICodemsts { get; }
        ISISeinoumstRepository SISeinoumsts { get; }

        ICommentRepository Comments { get; }

        // ⭐ ONLY for transaction-heavy operations
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
    }
}
