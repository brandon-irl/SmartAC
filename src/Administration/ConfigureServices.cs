using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Administration
{
    public static class ConfigureServices
    {
        public static void AddAdministration(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<AdministrationContext>(options => options.UseSqlite(configuration.GetConnectionString("Administration")));
            serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        }
    }
}