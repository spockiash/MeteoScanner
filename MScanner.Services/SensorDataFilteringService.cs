using MScanner.Models.Models;
using MScanner.Services.Api;
using System.Reactive.Linq;
using System.Reactive.Subjects;

namespace MScanner.Services
{
    public class SensorDataFilteringService : ISensorDataFilteringService
    {
        private readonly List<SensorDataModel> _sensorDataList = new List<SensorDataModel>();
        private readonly Subject<SensorDataModel> _sensorDataStream = new Subject<SensorDataModel>();
        private IObservable<IList<SensorDataModel>> _filteredList;



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
            _filteredList = debug.ToList();
            return debug;
        }

        public IObservable<List<SensorDataModel>> GetSensorDataListAsync()
        {
            return Observable.FromAsync(async () =>
            {
                return await Task.Run(() =>
                {
                    return _sensorDataList.ToList();
                });
            });
        }
    }


}