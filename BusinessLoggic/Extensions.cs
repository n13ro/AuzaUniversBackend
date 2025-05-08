using BusinessLogic.Services.Ment;
using BusinessLogic.Services.PairService;
using BusinessLogic.Services.Stud;
using DataAccess.Repository.Ment;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
