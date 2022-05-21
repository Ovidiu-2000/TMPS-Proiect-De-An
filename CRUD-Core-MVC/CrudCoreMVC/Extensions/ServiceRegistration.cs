using CrudCoreMVC.Services;
using Microsoft.Extensions.DependencyInjection;
using WebApplication1.Mementos;
using WebApplication1.Repositories;
using WebApplication1.Services.Factories;

namespace WebApplication1.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<ISchoolService, SchoolService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ISchoolRepository, SchoolRepository>();
            services.AddScoped<StudentSortingStrategyFactoryAbstract, StudentSortingStrategyFactory>();
        }
    }
}
