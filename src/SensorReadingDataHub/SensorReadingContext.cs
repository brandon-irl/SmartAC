using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace SensorReadingDataHub
{
    public class SensorReadingContext : DbContext
    {
        public DbSet<SensorReading> SensorReadings { get; set; }
        public SensorReadingContext(DbContextOptions<SensorReadingContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SensorReading>(entity =>
            {
                entity.HasKey(e => new { e.DeviceSerialNumber, e.Time });
                entity.Ignore(e => e.Alerts);
                entity.ToTable(nameof(SensorReading));
            });
        }
    }

    public class SensorReadingContextFactory : IDesignTimeDbContextFactory<SensorReadingContext>
    {
        public SensorReadingContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SensorReadingContext>();
            optionsBuilder.UseSqlite(args[0]);
            return new SensorReadingContext(optionsBuilder.Options);
        }
    }
}