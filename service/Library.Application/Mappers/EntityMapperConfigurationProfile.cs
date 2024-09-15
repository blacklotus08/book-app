using AutoMapper;
using Library.Application.PayloadModel;
using Library.Infrastructure.Entities;


namespace Library.Application.Mappers
{
    public class EntityMapperConfigurationProfile : Profile
    {
        public EntityMapperConfigurationProfile()
        {
            CreateMap<BookPayloadModel, BookEntity>();
        }
    }
}
