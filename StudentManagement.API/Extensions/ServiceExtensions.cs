using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.Application.Interfaces;
using StudentManagement.Application.Mappings;
using StudentManagement.Application.Services;
using StudentManagement.Application.Validator.RoleValidators;

namespace StudentManagement.API.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Đăng kí serivce
            //services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IStudentService, StudentService>();

            //Đăng kí fluentValidation
            services.AddFluentValidationAutoValidation();
           services.AddValidatorsFromAssemblyContaining<CreateRoleDtoValidator>();

            //Đăng kí map entity -> dto
            services.AddAutoMapper(typeof(StudentMappingProfile));

            //Đăng kí jwt
            services.AddAuthentication("Bearer").AddJwtBearer("Bearer", options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(configuration["Jwt:Key"])
                    ),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            return services;
        }
    }
}
