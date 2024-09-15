using Microsoft.EntityFrameworkCore;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Shared;
using Library.Infrastructure.Repository.Interfaces;

namespace Library.Infrastructure.Repository
{
    public class BookRepository :  Repository<BookEntity>, IBookRepository
    
    {
        public BookRepository(AppDbContext _context) : base(_context)
        {

        }

        public override async Task<BookEntity?> Get(Guid id)
        {
            return await _context.Set<BookEntity>().Where(entity => entity.Id == id && !entity.DeletedDateTimeUtc.HasValue).SingleOrDefaultAsync();
        }

        public override async Task<List<BookEntity>> GetAll()
        {
            return await _context.Set<BookEntity>().AsNoTracking().Where(entity => !entity.DeletedDateTimeUtc.HasValue).ToListAsync();
        }
        
    }
}
