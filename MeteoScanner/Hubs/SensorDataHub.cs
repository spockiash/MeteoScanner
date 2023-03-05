using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using MScanner.Models.Models;

namespace MeteoScanner.Api.Hubs
{
    public class SensorDataHub : Hub
    {
        private readonly IHubContext<SensorDataHub> _hubContext;

        public SensorDataHub(IHubContext<SensorDataHub> hubContext)
        {
            _hubContext = hubContext;
        }
        public async Task SendSensorData(SensorDataModel sensorData)
        {
            await _hubContext.Clients.All.SendAsync("ReceiveSensorData", sensorData);
        }
    }
}
