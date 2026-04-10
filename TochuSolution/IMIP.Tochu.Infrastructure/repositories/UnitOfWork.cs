using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TochuDBContext _context;
        private IDbContextTransaction? _transaction;

        public IUserRepository Users { get; }
        public IProductRepository Products { get; }
        public ISICodemstRepository SICodemsts { get; }
        public ISISeinoumstRepository SISeinoumsts { get; }
        public ICommentRepository Comments { get; }

        public UnitOfWork(
            TochuDBContext context,
            IUserRepository users,
            IProductRepository products,
            ISICodemstRepository codemsts,
            ISISeinoumstRepository seinoumsts,
            ICommentRepository comments)
        {
            _context = context;

            Users = users;
            Products = products;
            SICodemsts = codemsts;
            SISeinoumsts = seinoumsts;
            Comments = comments;
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitAsync()
        {
            try
            {
                await _context.SaveChangesAsync();

                if (_transaction != null)
                    await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                if (_transaction != null)
                {
                    await _transaction.DisposeAsync();
                    _transaction = null;
                }
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}