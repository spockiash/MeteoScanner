using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MScanner.Helpers
{
    using MScanner.Models.Models;
    using System;
    using System.Collections.Generic;

    public static class SensorTestSampleDataHelper
    {
        public static SensorDataModel GetTestSensorData()
        {
            var rand = new Random();
            return new SensorDataModel
            {
                Id = 0,
                Temperature = rand.Next(0, 100),
                Humidity = rand.Next(0, 100),
                UVIntensity = rand.Next(0, 100),
                AirQuality = rand.Next(0, 100),
                Timestamp = DateTime.Now
            };
        }

        public static List<SensorDataModel> GetTestSensorBulk()
        {
            var sensorDataList = new List<SensorDataModel>();
            for (int i = 0; i < 100; i++)
            {
                sensorDataList.Add(GetTestSensorData());
            }
            return sensorDataList;
        }
    }

}
