using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Registration
{
    public static class ConfigureServices
    {
        public static void AddRegistration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RegistrationContext>(options => options.UseSqlite(configuration.GetConnectionString("Registration")));
        }
    }
}