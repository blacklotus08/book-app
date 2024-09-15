using Library.Application.BusinessLogic;
using Library.Application.BusinessLogic.Interfaces;
using Library.Application.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Application
{
    public static class ApplicationService
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile(new EntityMapperConfigurationProfile());
                config.AddProfile(new ViewModelMapperConfigurationProfile());
            });

            services.AddScoped<IBookManagement, BookManagement>();


            return services;
        }
    }
}
