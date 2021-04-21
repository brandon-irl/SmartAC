using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MediatR;

namespace SensorReadingDataHub
{
    public static class ConfigureServices
    {
        public static void AddSensorReadingDataHub(this IServiceCollection serviceCollection, string connectionString)
        {
            serviceCollection.AddDbContext<SensorReadingContext>(options => options.UseSqlite(connectionString));;
            serviceCollection.AddMediatR(typeof(ConfigureServices).Assembly);
        }
    }
}