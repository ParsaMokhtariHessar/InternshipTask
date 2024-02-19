using InternshipTask.Application.ApplicationModels.Identity;
using InternshipTask.Identity.IdentityData;
using InternshipTask.Identity.IdentityModels;
using InternshipTask.Identity.Services.AuthService;
using InternshipTask.Identity.Services.UserService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace InternshipTask.Identity
{
    public static class IdentityServicesRegistration
    {

        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

            services.AddDbContext<IntershipTaskIdentityDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(("DefaultConnection"))));

            services.AddIdentity<ApplicationUser, IdentityRole<Guid>>(
                options => { options.User.RequireUniqueEmail = false; }
            ).AddEntityFrameworkStores<IntershipTaskIdentityDbContext>().AddDefaultTokenProviders();

            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IUserService, UserService>();

            string? issuer = configuration["JwtSettings:Issuer"];
            string? audience = configuration["JwtSettings:Audience"];
            string? jwtKey = configuration["JwtSettings:Key"];

            if (issuer == null || audience == null || jwtKey == null)
            {
                throw new InvalidOperationException("JwtSettings: Issuer, Audience, or Key is null");
            }

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = issuer,
                    ValidAudience = audience,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                };
            });

            return services;
        }
    }
}

