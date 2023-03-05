using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MScanner.Models.Models;

namespace MScanner.Services.Api
{
    public interface ISensorDataFilteringService
    {
        IObservable<SensorDataModel> SensorDataStream { get; }
        void AddSensorData(SensorDataModel sensorData);
        IObservable<SensorDataModel> FilterSensorDataStream(Func<SensorDataModel, bool> filterFunc);
    }

}
