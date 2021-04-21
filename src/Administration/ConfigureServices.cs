using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Administration
{
    public static class ConfigureServices
    {
        public static void AddAdministration(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<AdministrationContext>(options => options.UseSqlite(connectionString));
            serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        }
    }
}