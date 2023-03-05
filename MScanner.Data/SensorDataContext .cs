using Microsoft.EntityFrameworkCore;
using MScanner.Data.Entities;

namespace MScanner.Data
{
    public class SensorDataContext : DbContext
    {
        public DbSet<SensorDataEntity> SensorData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=C:\\Users\\bobo\\source\\repos\\MeteoScanner\\MScanner.Data\\sensor_data.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SensorDataEntity>().ToTable("SensorData");
            modelBuilder.Entity<SensorDataEntity>().HasKey(s => s.Id);
        }
    }
}