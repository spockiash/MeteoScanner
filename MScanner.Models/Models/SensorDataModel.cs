namespace MScanner.Models.Models
{
    public class SensorDataModel
    {
        public int Id { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double WindSpeed { get; set; }
        public double WindDirection { get; set; }
        public DateTime Timestamp { get; set; }
    }

}
