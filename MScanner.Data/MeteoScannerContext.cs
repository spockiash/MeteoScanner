using Microsoft.EntityFrameworkCore;
using MScanner.Data.Entities;
using MScanner.Data.Entities.RequestPresets;

namespace MScanner.Data
{
    public class MeteoScannerContext : DbContext
    {
        public MeteoScannerContext(DbContextOptions<MeteoScannerContext> options) : base(options)
        {
        }
        public DbSet<SensorDataEntity> SensorData { get; set; } = null!;
        public DbSet<OpenAqRequestPreset> ApiRequestPresets { get; set; } = null!;
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorDataEntity>().ToTable("SensorData");
            modelBuilder.Entity<SensorDataEntity>().HasKey(s => s.Id);

            modelBuilder.Entity<OpenAqRequestPreset>().ToTable("OpenAqPresets");
            modelBuilder.Entity<OpenAqRequestPreset>().HasKey(p => p.Id);
        }
    }
}