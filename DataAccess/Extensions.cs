using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using DataAccess.Repository.Stud;
using DataAccess.Repository.Ment;
using DataAccess.Repository.GroupRepo;
using DataAccess.Repository.PairRepo;

namespace DataAccess;

public static class Extensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection services)
    {
        services.AddScoped<IStudentRepository, StudentRepository>();
        services.AddScoped<IMentorRepository, MentorRepository>();
        //services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IPairRepository, PairRepository>();

        services.AddDbContext<AppDbContext>(ctx =>
        {
            ctx.UseNpgsql("Host=localhost;Port=5432;Database=AuzaUniversDb;Username=postgres;Password=12345");
        });

        return services;
    }
}

    