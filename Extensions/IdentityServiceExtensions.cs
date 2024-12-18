using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using security_system.Models;
using security_system.Data;

namespace security_system.Extensions
{
    public static class IdentityServiceExtensions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 3;
                opt.Password.RequireNonAlphanumeric = false;
                opt.Password.RequireUppercase = false;
                opt.Password.RequireLowercase = false;
            })
                .AddRoles<AppRole>()
            .AddRoleManager<RoleManager<AppRole>>()
                .AddEntityFrameworkStores<SecuritySystemDbContext>();

            var tokenKey = config["TokenKey"] ?? throw new Exception("Token key not found");

            if (tokenKey.Length < 8)
            {
                throw new Exception("Token key needs to be at least 64 characters long for security");
            }

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            services.AddAuthorization(options =>
            {
                options.AddPolicy("User", policy => policy.RequireRole("SupremeAdmin"));
                options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
            });

            return services;
        }

    }
}
