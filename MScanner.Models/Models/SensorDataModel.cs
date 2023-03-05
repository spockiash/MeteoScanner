namespace MScanner.Models.Models
{
    public class SensorDataModel
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double UVIntensity { get; set; }
        public double AirQuality { get; set; }
        public DateTime Timestamp { get; set; }
    }

}

