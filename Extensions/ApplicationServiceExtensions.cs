using Microsoft.EntityFrameworkCore;
using security_system.Data;
using security_system.Data.Implementations;
using security_system.Data.Interfaces;
using security_system.Services.Implementations;
using security_system.Services.Interfaces;
using System;

namespace security_system.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddCors(options =>
            {
                options.AddPolicy("AllowLocalhost", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<SecuritySystemDbContext>(
                    options => options.UseSqlServer("name=ConnectionStrings:DefaultConnection"));

            services.AddScoped<ITokenService, TokenService>();




            services.AddScoped<ISensorRepository, SensorRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IUserService, UserService>();



            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSignalR();

            return services;
        }
    }
}
