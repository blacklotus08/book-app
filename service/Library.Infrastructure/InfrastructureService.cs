using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Library.Infrastructure.Repository;
using Library.Infrastructure.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Library.Infrastructure
{
    public static class InfrastructureService
    {

        public static IServiceCollection AddInfrastuctureService(this IServiceCollection services ,IConfiguration configuration)
        {
            MySqlServerVersion mysqlVersion = new MySqlServerVersion(new Version(8, 0, 38));
            // Configure AppDbContext with SQL Server and a connection string
            services.AddDbContext<AppDbContext>((options) =>
            {
                options.UseMySql(configuration.GetConnectionString("MySql"), mysqlVersion , x=> x.MigrationsAssembly("Library.Infrastructure"))
                .LogTo(Console.WriteLine, LogLevel.Information)
                .EnableSensitiveDataLogging() //for development environment only
                .EnableDetailedErrors(); //for development environment only

            });

            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
