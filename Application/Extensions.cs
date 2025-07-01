using Application.Commands.CreateGroup;
using Application.Commands.CreateStudent;
using Microsoft.Extensions.DependencyInjection;


namespace Application
{
    public static class Extensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateStudentCommand>());
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<CreateGroupCommand>());

           
            return services;
        }
    }
}
