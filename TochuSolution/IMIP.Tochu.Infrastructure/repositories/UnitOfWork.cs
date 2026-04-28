using IMIP.Tochu.Domain.interfaces;
using IMIP.Tochu.Domain.Interfaces;
using IMIP.Tochu.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.Storage;

namespace IMIP.Tochu.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TochuDBContext _context;
        private IDbContextTransaction? _transaction;

        public ISI_CODEMSTRepository SI_CODEMST { get; private set; }

        public ISI_MEMORepository SI_MEMO { get; private set; }

        public ISI_SEINOUDATARepository SI_SEINOUDATA { get; private set; }

        public ISI_SEINOUMSTRepository SI_SEINOUMST { get; private set; }

        public ISI_TANTOURepository SI_TANTOU { get; private set; }

        public IT0000MS_Item_RCSRepository T0000MS_Item_RCS { get; private set; }

        public IT0000RR_Juchuu_RCSRepository T0000RR_Juchuu_RCS { get; private set; }

        public UnitOfWork(
            TochuDBContext context,
            ISI_SEINOUMSTRepository si_seinoumst,
            ISI_SEINOUDATARepository si_SEINOUDATA,
            ISI_CODEMSTRepository si_CODEMST,
            ISI_MEMORepository si_MEMO,
            ISI_TANTOURepository sI_TANTOURepository, 
            IT0000MS_Item_RCSRepository t0000MS_Item_RCS,
            IT0000RR_Juchuu_RCSRepository t0000RR_Juchuu_RCS)
        {
            _context = context;
            SI_SEINOUMST = si_seinoumst;
            SI_SEINOUDATA = si_SEINOUDATA;
            SI_CODEMST = si_CODEMST;
            SI_MEMO = si_MEMO;
            SI_TANTOU = sI_TANTOURepository;
            T0000MS_Item_RCS = t0000MS_Item_RCS;
            T0000RR_Juchuu_RCS = t0000RR_Juchuu_RCS;
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