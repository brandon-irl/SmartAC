using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Registration
{
    public class RegistrationContext : DbContext
    {

        public DbSet<Device> Devices { get; set; }
        public RegistrationContext(DbContextOptions<RegistrationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Device>(entity =>
            {
                entity.HasKey(e => e.SerialNumber);
                entity.ToTable(nameof(Device));
            });

        }
    }

    public class RegistrationContextFactory : IDesignTimeDbContextFactory<RegistrationContext>
    {
        public RegistrationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<RegistrationContext>();
            optionsBuilder.UseSqlite(args[0]);
            return new RegistrationContext(optionsBuilder.Options);
        }
    }
}