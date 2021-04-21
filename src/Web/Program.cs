using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Registration;
using SensorReadingDataHub;
using Administration;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            // This is only for ease of protoyping
            using(var scope = host.Services.CreateScope())
            {
                var registrationDb = scope.ServiceProvider.GetRequiredService<RegistrationContext>();
                registrationDb.Database.Migrate();
                var deviceDb = scope.ServiceProvider.GetRequiredService<SensorReadingContext>();
                deviceDb.Database.Migrate();
                var administrationDb = scope.ServiceProvider.GetRequiredService<AdministrationContext>();
                administrationDb.Database.Migrate();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
