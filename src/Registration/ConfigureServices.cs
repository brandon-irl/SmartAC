using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Registration
{
    public static class ConfigureServices
    {
        public static void AddRegistration(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<RegistrationContext>(options => options.UseSqlite(connectionString));
            serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        }
    }
}