using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using API.Services;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;
using API.Data;
using AutoMapper;
using API.Helpers;

namespace API.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config) 
        {
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddAutoMapper(typeof(AutoMapperProfiles).Assembly);
            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });
            return services;
        }
    }
}