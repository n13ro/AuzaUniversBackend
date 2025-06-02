using BusinessLogic.Services.Ment;
using BusinessLogic.Services.PairService;
using BusinessLogic.Services.Stud;
using Microsoft.Extensions.DependencyInjection;


namespace BusinessLogic
{
    public static class Extensions
    {
        public static IServiceCollection AddBusinessLogic(this IServiceCollection services)
        {

            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMentorService, MentorService>();
            services.AddScoped<IPairService, PairService>();
            
            return services;
        }
        
    }
}
