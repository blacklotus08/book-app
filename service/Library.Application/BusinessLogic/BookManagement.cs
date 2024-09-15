using AutoMapper;
using Library.Application.BusinessLogic.Interfaces;
using Library.Application.PayloadModel;
using Library.Application.ViewModel;
using Library.Infrastructure.Entities;
using Library.Infrastructure.Repository.Interfaces;
using Library.Domain.Common;

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

        public Task<ResponsePayload<BookViewModel>> CreateBook(BookPayloadModel payload)
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePayload<BookViewModel>> DeleteBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePayload<List<BookViewModel>>> GetAllBooks()
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePayload<BookViewModel>> GetBook(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<ResponsePayload<BookViewModel>> UpdateBook(Guid id, BookPayloadModel payload)
        {
            throw new NotImplementedException();
        }


        // public async Task<ResponsePayload<UserViewModel>> GetUser(Guid id)
        // {
        //     UserEntity? userEntity = await _userRepository.Get(id);

        //     if (userEntity == null)
        //     {
        //         return new ResponsePayload<UserViewModel>
        //         {
        //             Data = null,
        //             IsSuccess = false,
        //             ErrorMessage = string.Format(Localization.NoRecordFound, typeof(UserEntity).FullName),
        //             UIFriendlyMessage = string.Format(Localization.NoRecordFound, typeof(UserEntity).FullName)
        //         };
        //     }

        //     UserViewModel data = _mapper.Map<UserViewModel>(userEntity);

        //     return new ResponsePayload<UserViewModel>
        //     {
        //         Data = data,
        //         IsSuccess = true,
        //         ErrorMessage = string.Empty,
        //         UIFriendlyMessage = Localization.FriendlySuccessMessage
        //     };
        // }

        // public async Task<ResponsePayload<List<UserViewModel>>> GetAllUsers()
        // {
        //     List<UserViewModel> data = _mapper.Map<List<UserViewModel>>(await _userRepository.GetAll());

        //     return new ResponsePayload<List<UserViewModel>>
        //     {
        //         Data = data,
        //         IsSuccess = true,
        //         ErrorMessage = string.Empty,
        //         UIFriendlyMessage = Localization.FriendlySuccessMessage
        //     };
        // }

        // public async Task<ResponsePayload<UserViewModel>> CreateUser(UserPayloadModel payload)
        // {
        //     UserEntity userEntity = _mapper.Map<UserEntity>(payload);

        //     bool isUsernameExists = await _userRepository.GetUserNameExists(userEntity.Username);

        //     if(isUsernameExists)
        //     {
        //         return new ResponsePayload<UserViewModel>
        //         {
        //             Data = null,
        //             IsSuccess = false,
        //             ErrorMessage = string.Format(Localization.UsernameExists, "Creating User"),
        //             UIFriendlyMessage = Localization.FriendlyErrorMessage
        //         };
        //     }

        //     byte[] salt = _authSecurityHelper.CreateSalt();
        //     byte[] hash = _authSecurityHelper.HashPassword(userEntity.Password, salt);

        //     userEntity.Password = Convert.ToBase64String(hash);
        //     userEntity.Salt = Convert.ToBase64String(salt);

        //     await _userRepository.Insert(userEntity);

        //     bool isSuccess = await _userRepository.Persist();

        //     return new ResponsePayload<UserViewModel>
        //     {
        //         Data = null,
        //         IsSuccess = isSuccess,
        //         ErrorMessage = isSuccess ? string.Empty : string.Format(Localization.ErrorOnPersist, "Creating User"),
        //         UIFriendlyMessage = isSuccess ? Localization.FriendlySuccessMessage : Localization.FriendlyErrorMessage
        //     };
        // }


        // public async Task<ResponsePayload<UserViewModel>> UpdateUser(Guid id, UserUpdatePayloadModel payload)
        // {

        //     UserEntity? userEntity = await _userRepository.Get(id);

        //     if (userEntity == null)
        //     {
        //         return new ResponsePayload<UserViewModel>
        //         {
        //             Data = null,
        //             IsSuccess = false,
        //             ErrorMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(UserEntity))),
        //             UIFriendlyMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(UserEntity)))
        //         };
        //     }
        //     _mapper.Map(payload, userEntity);

        //     _userRepository.Update(userEntity);

        //     bool isSuccess = await _userRepository.Persist();

        //     return new ResponsePayload<UserViewModel>
        //     {
        //         Data = null,
        //         IsSuccess = isSuccess,
        //         ErrorMessage = isSuccess ? string.Empty : string.Format(Localization.ErrorOnPersist, "Updating User"),
        //         UIFriendlyMessage = isSuccess ? Localization.FriendlySuccessMessage : Localization.FriendlyErrorMessage
        //     };
        // }

        // public async Task<ResponsePayload<UserViewModel>> DeleteUser(Guid id)
        // {

        //     UserEntity? userEntity = await _userRepository.Get(id);

        //     if (userEntity == null)
        //     {
        //         return new ResponsePayload<UserViewModel>
        //         {
        //             Data = null,
        //             IsSuccess = false,
        //             ErrorMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(UserEntity))),
        //             UIFriendlyMessage = string.Format(Localization.NoRecordFound, Localization.GetEntityFriendlyName(typeof(UserEntity)))
        //         };
        //     }
        //     _userRepository.Delete(userEntity);

        //     bool isSuccess = await _userRepository.Persist();

        //     return new ResponsePayload<UserViewModel>
        //     {
        //         Data = null,
        //         IsSuccess = isSuccess,
        //         ErrorMessage = isSuccess ? string.Empty : string.Format(Localization.ErrorOnPersist, "Deleting User"),
        //         UIFriendlyMessage = isSuccess ? Localization.FriendlySuccessMessage : Localization.FriendlyErrorMessage
        //     };
        // }

    }
}
