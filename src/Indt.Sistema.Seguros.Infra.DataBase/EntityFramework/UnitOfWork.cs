using Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks;
using Microsoft.EntityFrameworkCore.Storage;

namespace Indt.Sistema.Seguros.Infra.DataBase.EntityFramework
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SegurosContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(SegurosContext context)
        {
            _context = context;
        }

        public virtual async Task BeginTransaction(CancellationToken cancellationToken = default)
        {
            if (_transaction is null)
                _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public Task CommitTransaction(CancellationToken cancellationToken = default)
        {
            return _transaction.CommitAsync(cancellationToken);
        }

        public Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }

        public void DetectChanges()
        {
            _context.ChangeTracker.DetectChanges();
        }

        public void DisableAutoDetectChanges()
        {
            _context.ChangeTracker.AutoDetectChangesEnabled = false;
        }
    }
}
