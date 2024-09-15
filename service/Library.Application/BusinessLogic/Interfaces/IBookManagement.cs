using Library.Application.PayloadModel;
using Library.Application.ViewModel;
using Library.Domain.Common;

namespace Library.Application.BusinessLogic.Interfaces
{
    public interface IBookManagement
    {
        Task<ResponsePayload<List<BookViewModel>>> GetAllBooks();
        Task<ResponsePayload<BookViewModel>> GetBook(Guid id);
        Task<ResponsePayload<BookViewModel>> CreateBook(Book payload);
        Task<ResponsePayload<BookViewModel>> UpdateBook(Guid id, Book payload);
        Task<ResponsePayload<BookViewModel>> DeleteBook(Guid id);
    }
}
