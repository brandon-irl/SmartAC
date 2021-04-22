using System;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Registration.Authentication;

namespace Registration
{
    public static class ConfigureServices
    {
        public static void AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RegistrationContext>(options => options.UseSqlite(configuration.GetConnectionString("Registration")));
            services.AddMediatR(typeof(ConfigureServices).Assembly);

            var section = configuration.GetSection("AppSettings");
            var settings = section.Get<AppSettings>();
            var signingKey = Encoding.UTF8.GetBytes(settings.EncryptionKey);

            services.AddAuthentication()
                    .AddJwtBearer(jwtOptions =>
                    {
                        jwtOptions.SaveToken = true;
                        jwtOptions.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateAudience = false,
                            ValidateIssuer = false,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(signingKey),
                            ValidateLifetime = true,
                            LifetimeValidator = LifetimeValidator
                        };
                    });

            bool LifetimeValidator(DateTime? notBefore,
                DateTime? expires,
                SecurityToken securityToken,
                TokenValidationParameters validationParameters)
            {
                return expires != null && expires > DateTime.Now;
            }

            services.Configure<AppSettings>(section);
            services.AddTransient<AuthenticationService>();
            services.AddTransient<DeviceValidationService>();
            services.AddTransient<TokenService>();
        }
    }
}