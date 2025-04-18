using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Stud;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddDbContext<AppDbContext>(x =>
        {
            x.UseNpgsql("Host=localhost;Port=5432;Database=AuzaUniversDb;Username=postgres;Password=12345");
        });

        return services;
    }
}

    