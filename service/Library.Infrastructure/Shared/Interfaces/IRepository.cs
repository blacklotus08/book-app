using Library.Infrastructure.Classes.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace Library.Infrastructure.Shared.Interfaces
{
    public interface IRepository<T> where T : IAuditableEntity
    {
        Task<IDbContextTransaction> BeginTransaction();
        Task CommitTransaction(IDbContextTransaction transaction);
        Task RollbackTransaction(IDbContextTransaction transaction);

        Task<T?> Get(Guid id);
        Task<T?> GetNoTracking(Guid id);
        Task<List<T>> GetAll();
        Task Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task<bool> Persist();

    }
}
