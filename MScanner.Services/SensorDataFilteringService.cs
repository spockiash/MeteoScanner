using MScanner.Models.Models;
using MScanner.Services.Api;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using MScanner.Infra;

namespace MScanner.Services
{
    public class SensorDataFilteringService : ISensorDataFilteringService
    {
        private readonly List<SensorDataModel> _sensorDataList = new List<SensorDataModel>();
        private readonly Subject<SensorDataModel> _sensorDataStream = new Subject<SensorDataModel>();
        private IObservable<IList<SensorDataModel>> _filteredList;
        private SensorDataCollector Collector;

        public SensorDataFilteringService(SensorDataCollector collector)
        {
            Collector = collector;
        }

        public IObservable<SensorDataModel> SensorDataStream => _sensorDataStream.AsObservable();

        public void AddSensorData(SensorDataModel sensorData)
        {
            _sensorDataList.Add(sensorData);
            _sensorDataStream.OnNext(sensorData);
        }

        public IObservable<SensorDataModel> FilterSensorDataStream(Func<SensorDataModel, bool> filterFunc)
        {
            var x = new SensorDataModel();
            var debug = SensorDataStream.Where(filterFunc);
            SensorDataStream.Subscribe(sensorData => Console.WriteLine($"Received sensor data: {sensorData}"));
            SensorDataStream.Subscribe(sensorData => x = sensorData);
            _filteredList = debug.ToList();
            return debug;
        }
    }


}