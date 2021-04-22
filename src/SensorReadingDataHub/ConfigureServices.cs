using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;

namespace SensorReadingDataHub
{
    public static class ConfigureServices
    {
        public static void AddSensorReadingDataHub(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            serviceCollection.AddDbContext<SensorReadingContext>(options => options.UseSqlite(configuration.GetConnectionString("SensorReadingDataHub")));;
            serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        }
    }
}