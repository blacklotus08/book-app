using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Library.Infrastructure.Repository;
using Library.Infrastructure.Repository.Interfaces;

namespace Library.Infrastructure
{
    public static class InfrastructureService
    {

        public static IServiceCollection AddInfrastuctureService(this IServiceCollection services ,IConfiguration configuration)
        {
            
            services.AddDbContext<AppDbContext>((options) =>
            {

            });

            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
