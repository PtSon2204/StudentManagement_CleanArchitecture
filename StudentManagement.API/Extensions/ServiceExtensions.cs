using FluentValidation;
using FluentValidation.AspNetCore;
using StudentManagement.Application.Interfaces;
using StudentManagement.Application.Services;
using StudentManagement.Application.Validator.RoleValidators;

namespace StudentManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            //Đăng kí serivce
            //services.AddScoped<IStudentService, StudentService>();
            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IDepartmentService, DepartmentService>();

            //Đăng kí fluentValidation
            services.AddFluentValidationAutoValidation();
           services.AddValidatorsFromAssemblyContaining<CreateRoleDtoValidator>();
            return services;
        }
    }
}
