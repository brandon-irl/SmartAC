using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Administration
{
    public class AdministrationContext : DbContext
    {

        public DbSet<Alert> Alerts { get; set; }
        public AdministrationContext(DbContextOptions<AdministrationContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Alert>(entity =>
            {
                entity.ToTable(nameof(Alert));
            });

        }
    }

    public class AdministrationContextFactory : IDesignTimeDbContextFactory<AdministrationContext>
    {
        public AdministrationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AdministrationContext>();
            optionsBuilder.UseSqlite(args[0]);
            return new AdministrationContext(optionsBuilder.Options);
        }
    }
}