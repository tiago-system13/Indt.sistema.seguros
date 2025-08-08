namespace Indt.Sistema.Seguros.Domain.Adapters.UnitOfWorks
{
    public interface IUnitOfWork
    {
        Task BeginTransaction(CancellationToken cancellationToken = default);
        Task CommitTransaction(CancellationToken cancellationToken = default);
        Task SaveChangesAsync(CancellationToken cancellationToken = default);
        void DetectChanges();

        void DisableAutoDetectChanges();

    }
}
