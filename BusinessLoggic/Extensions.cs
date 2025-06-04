using BusinessLogic.Services.Ment;
using BusinessLogic.Services.PairService;
using BusinessLogic.Services.Stud;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace BusinessLogic
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IPairService, PairService>();

            return services;
        }
        
    }
}
