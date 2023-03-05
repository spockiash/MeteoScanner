using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MScanner.Data.Entities
{
    [Table("SensorData")]
    public class SensorDataEntity
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public double Temperature { get; set; }

        [Required]
        public double Humidity { get; set; }

        [Required]
        public double UVIntensity { get; set; }

        [Required]
        public double AirQuality { get; set; }

        [Required]
        public DateTime TimeStamp { get; set; }
    }
}