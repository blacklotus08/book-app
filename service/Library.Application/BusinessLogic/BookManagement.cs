using Library.Application.BusinessLogic.Interfaces;
using Library.Application.PayloadModel;
using Library.Application.ViewModel;
using Library.Infrastructure.Repository.Interfaces;
using Library.Domain.Common;
using AutoMapper;
using Library.Infrastructure.Entities;

namespace Library.Application.BusinessLogic
{
    public class BookManagement : IBookManagement
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        public BookManagement(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<ResponsePayload<BookViewModel>> CreateBook(Book payload)
        {
            BookEntity? bookEntity = _mapper.Map<BookEntity>(payload);
            bool isSuccess = false;
            if (bookEntity != null) {
                await _bookRepository.Insert(bookEntity);
                isSuccess = await _bookRepository.Persist();
            }

            return new ResponsePayload<BookViewModel>
            {
                Data = null,
                IsSuccess = isSuccess,
                ErrorMessage = isSuccess ? string.Empty : string.Format(Localization.ErrorOnPersist, "Adding Book"),
                UIFriendlyMessage = isSuccess ? Localization.FriendlySuccessMessage : Localization.FriendlyErrorMessage
            };

        }

        public async Task<ResponsePayload<BookViewModel>> DeleteBook(int id)
        {
            BookEntity? bookEntity = await _bookRepository.Get(id);

            if (bookEntity == null)
            {
                return new ResponsePayload<BookViewModel>
                {
                    Data = null,
                    IsSuccess = false,
                    ErrorMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(BookEntity))),
                    UIFriendlyMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(BookEntity)))
                };
            }
            _bookRepository.Delete(bookEntity);

            bool isSuccess = await _bookRepository.Persist();

            return new ResponsePayload<BookViewModel>
            {
                Data = null,
                IsSuccess = isSuccess,
                ErrorMessage = isSuccess ? string.Empty : string.Format(Localization.ErrorOnPersist, "Deleting book"),
                UIFriendlyMessage = isSuccess ? Localization.FriendlySuccessMessage : Localization.FriendlyErrorMessage
            };
        }

        public async Task<ResponsePayload<List<BookViewModel>>> GetAllBooks()
        {
            List<BookViewModel>? data = _mapper.Map<List<BookViewModel>>(await _bookRepository.GetAll());

            return new ResponsePayload<List<BookViewModel>>
            {
                Data = data,
                IsSuccess = true,
                ErrorMessage = string.Empty,
                UIFriendlyMessage = Localization.FriendlySuccessMessage
            };
        }

        public async Task<ResponsePayload<BookViewModel>> GetBook(int id)
        {
            BookEntity? bookEntity = await _bookRepository.Get(id);

            if (bookEntity == null)
            {
                return new ResponsePayload<BookViewModel>
                {
                    Data = null,
                    IsSuccess = false,
                    ErrorMessage = string.Format(Localization.NoRecordFound, typeof(BookEntity).FullName),
                    UIFriendlyMessage = string.Format(Localization.NoRecordFound, typeof(BookEntity).FullName)
                };
            }

            BookViewModel? data = _mapper.Map<BookViewModel>(bookEntity);

            return new ResponsePayload<BookViewModel>
            {
                Data = data,
                IsSuccess = true,
                ErrorMessage = string.Empty,
                UIFriendlyMessage = Localization.FriendlySuccessMessage
            };
        }

        public async Task<ResponsePayload<BookViewModel>> UpdateBook(int id, Book payload)
        {
            BookEntity? bookEntity = await _bookRepository.Get(id);

            if (bookEntity == null)
            {
                return new ResponsePayload<BookViewModel>
                {
                    Data = null,
                    IsSuccess = false,
                    ErrorMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(BookEntity))),
                    UIFriendlyMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(BookEntity)))
                };
            }
            _mapper.Map(payload, bookEntity);
            _bookRepository.Update(bookEntity);

            bool isSuccess = await _bookRepository.Persist();

            return new ResponsePayload<BookViewModel>
            {
                Data = null,
                IsSuccess = isSuccess,
                ErrorMessage = isSuccess ? string.Empty : string.Format(Localization.ErrorOnPersist, "Updating book"),
                UIFriendlyMessage = isSuccess ? Localization.FriendlySuccessMessage : Localization.FriendlyErrorMessage
            };
        }
    }
}
