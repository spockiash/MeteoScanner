using Microsoft.AspNetCore.SignalR;
using MScanner.Models.Models;

namespace MeteoScanner.Api.Hubs
{
    public class SensorDataHub : Hub
    {
        public async Task SendSensorData(SensorDataModel sensorData)
        {
            await Clients.All.SendAsync("ReceiveSensorData", sensorData);
        }
    }
}
