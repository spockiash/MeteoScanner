using MScanner.Models.Models;

namespace MScanner.Infra
{
    public class SensorDataCollector : IObserver<SensorDataModel>
    {
        private List<SensorDataModel> _dataList = new List<SensorDataModel>();

        public void OnCompleted()
        {
            // Do nothing - this example doesn't require handling completion
        }

        public void OnError(Exception error)
        {
            // Handle error here if necessary
        }

        public void OnNext(SensorDataModel value)
        {
            _dataList.Add(value);
        }

        public IReadOnlyList<SensorDataModel> GetDataList()
        {
            return _dataList.AsReadOnly();
        }
    }

}