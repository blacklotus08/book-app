using Library.Infrastructure.Shared.Interfaces;

namespace Library.Infrastructure.Repository.Interfaces
{
    public interface IBookRepository : IBookRepository<BookRepository>
    {
    }

    public interface IBookRepository<T>
    {
    }
}
