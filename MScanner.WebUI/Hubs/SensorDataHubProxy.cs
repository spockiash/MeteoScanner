using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;
using MScanner.Models.Models;

namespace MScanner.WebUI.Hubs
{
    namespace MScanner.WebUI.Hubs
    {
        public class SensorDataHubProxy
        {
            private readonly HubConnection _hubConnection;

            public SensorDataHubProxy(HubConnection hubConnection)
            {
                _hubConnection = hubConnection;
            }

            public async Task ConnectAsync()
            {
                await _hubConnection.StartAsync();
            }

            public async Task DisconnectAsync()
            {
                await _hubConnection.StopAsync();
            }

            public event Action<SensorDataModel> SensorDataReceived;

            public void RegisterHandlers()
            {
                _hubConnection.On<SensorDataModel>("ReceiveSensorData", (sensorData) =>
                {
                    SensorDataReceived?.Invoke(sensorData);
                });
            }
        }
    }

}
