
using Microsoft.AspNetCore.SignalR.Client;

namespace MScanner.Factories
{
    public interface IHubConnectionFactory
    {
        HubConnection GetConnectionBuilder(string url);
    }

    public class HubConnectionFactory : IHubConnectionFactory
    {
        public HubConnection GetConnectionBuilder(string url)
        {
            return new HubConnectionBuilder()
                .WithUrl(url)
                .WithAutomaticReconnect()
                .Build();
        }
    }
}
