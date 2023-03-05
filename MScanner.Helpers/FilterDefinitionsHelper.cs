using MScanner.Models.Models;

namespace MScanner.Helpers
{
    public static class FilterDefinitionsHelper
    {
        public static Func<SensorDataModel, bool> TemperatureFilter(double min, double max)
        {
            return data => data.Temperature >= min && data.Temperature <= max;
        }

        public static Func<SensorDataModel, bool> HumidityFilter(double min, double max)
        {
            return data => data.Humidity >= min && data.Humidity <= max;
        }

        public static Func<SensorDataModel, bool> UVIntensityFilter(double min, double max)
        {
            return data => data.UVIntensity >= min && data.UVIntensity <= max;
        }

        public static Func<SensorDataModel, bool> AirQualityFilter(double min, double max)
        {
            return data => data.AirQuality >= min && data.AirQuality <= max;
        }
    }

}