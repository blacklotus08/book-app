using Library.Infrastructure.Classes.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Library.Infrastructure.Shared.Interfaces;

namespace Library.Infrastructure.Shared
{
    public class Repository<T> : IRepository<T> where T : class, IAuditableEntity
    {
        protected readonly AppDbContext _context;

        public Repository(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();
            return transaction;
        }
        public async Task CommitTransaction(IDbContextTransaction transaction)
        {
            await transaction.CommitAsync();
        }
        public async Task RollbackTransaction(IDbContextTransaction transaction)
        {
            await transaction.RollbackAsync();
        }
        public virtual async Task<T?> Get(int id)
        {
            return await _context.Set<T>().Where(entity => entity.Id == id &&  !entity.DeletedDateTimeUtc.HasValue).SingleOrDefaultAsync();
        }
        public virtual async Task<T?> GetNoTracking(int id)
        {
            return await _context.Set<T>().AsNoTracking().Where(entity => entity.Id == id && !entity.DeletedDateTimeUtc.HasValue).SingleOrDefaultAsync();
        }
        public virtual async Task<List<T>> GetAll()
        { 
            return await _context.Set<T>().AsNoTracking().Where(entity => !entity.DeletedDateTimeUtc.HasValue).ToListAsync();
        }
        public async Task Insert(T entity)
        {
            entity.CreatedById = Guid.NewGuid(); //TODO change to actual login
            entity.CreatedDateTimeUtc = DateTime.UtcNow;
            await _context.AddAsync(entity);
        }
        public void Update(T entity)
        {
            entity.LastModifiedById = Guid.NewGuid(); //TODO change to actual login
            entity.LastModifiedDateTimeUtc = DateTime.UtcNow;
            _context.Update(entity);
        }
        public void Delete(T entity)
        {
            entity.DeletedById = Guid.NewGuid(); //TODO change to actual login
            entity.DeletedDateTimeUtc = DateTime.UtcNow;
            _context.Update(entity);
        }
        public async Task<bool> Persist()
        {
            int result = await _context.SaveChangesAsync();
            return result > 0;
        }
    }
}
