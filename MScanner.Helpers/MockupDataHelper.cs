using MScanner.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Helpers
{
    public static class MockupDataHelper
    {
        private const int TempMin = -45;
        private const int TempMax = 60;
        private const int HumidityMin = 0;
        private const int HumidityMax = 100;
        private const int WindSpeedMin = 0;
        private const int WindSpeedMax = 300;
        private const int WindDirMin = 0;
        private const int WindDirMax = 360;
        private const int PercentChangeMin = -5;
        private const int PercentChangeMax = 5;

        public static SensorDataModel GetMockupInitData()
        {
            var random = new Random();
            return new SensorDataModel
            {
                Temperature = random.Next(TempMin, TempMax),
                Humidity = random.Next(HumidityMin, HumidityMax),
                WindSpeed = random.Next(WindSpeedMin, WindSpeedMax),
                WindDirection = random.Next(WindDirMin, WindDirMax),
                Timestamp = DateTime.UtcNow
            };
        }

        public static SensorDataModel GetNextMockup(SensorDataModel currentData)
        {
            var random = new Random();
            var newData = new SensorDataModel
            {
                Temperature = CalculateNewValue(currentData.Temperature, PercentChangeMin, PercentChangeMax, TempMin, TempMax),
                Humidity = CalculateNewValue(currentData.Humidity, PercentChangeMin, PercentChangeMax, HumidityMin, HumidityMax),
                WindSpeed = CalculateNewValue(currentData.WindSpeed, PercentChangeMin, PercentChangeMax, WindSpeedMin, WindSpeedMax),
                WindDirection = CalculateNewValue(currentData.WindDirection, PercentChangeMin, PercentChangeMax, WindDirMin, WindDirMax),
                Timestamp = DateTime.UtcNow
            };
            return newData;
        }

        private static double CalculateNewValue(double currentValue, int percentChangeMin, int percentChangeMax, int minValue, int maxValue)
        {
            var random = new Random();
            var percentChange = random.Next(percentChangeMin, percentChangeMax);
            var newPercent = 1 + (percentChange / 100.0);
            var newValue = currentValue * newPercent;
            if (newValue > maxValue)
            {
                return Math.Round((double) maxValue, 2);
            }
            else if (newValue < minValue)
            {
                return Math.Round((double) minValue, 2);
            }
            else
            {
                return Math.Round(newValue, 2);
            }
        }
    }
}
