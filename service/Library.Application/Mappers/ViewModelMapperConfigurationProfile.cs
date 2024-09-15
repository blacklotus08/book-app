using AutoMapper;
using Library.Application.ViewModel;
using Library.Infrastructure.Entities;

namespace Library.Application.Mappers
{
    public class ViewModelMapperConfigurationProfile : Profile
    {
        public ViewModelMapperConfigurationProfile()
        {
            CreateMap<BookEntity, BookViewModel>();

        }
    }
}
