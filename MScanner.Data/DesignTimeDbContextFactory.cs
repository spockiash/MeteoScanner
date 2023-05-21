using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace MScanner.Data
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MeteoScannerContext>
    {
        public MeteoScannerContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<MeteoScannerContext>();
            optionsBuilder.UseSqlite(connectionString);

            return new MeteoScannerContext(optionsBuilder.Options);
        }
    }
}
