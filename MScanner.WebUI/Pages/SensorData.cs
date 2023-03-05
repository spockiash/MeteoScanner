using Microsoft.AspNetCore.Components;
using MScanner.WebUI.Hubs.MScanner.WebUI.Hubs;

namespace MScanner.WebUI.Pages
{
    public partial class SensorData : ComponentBase
    {
        private readonly SensorDataHubProxy _sensorDataHubProxy;

        public SensorData(SensorDataHubProxy sensorDataHubProxy)
        {
            _sensorDataHubProxy = sensorDataHubProxy;
        }

        // rest of the component
    }
}
