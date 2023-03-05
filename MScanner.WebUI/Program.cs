using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MScanner.WebUI;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.AspNetCore.Components;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
// Add the SignalR client service
builder.Services.AddSingleton(s =>
    new HubConnectionBuilder()
        .WithUrl(s.GetService<NavigationManager>()?.ToAbsoluteUri("/sensorDataHub") ?? throw new InvalidOperationException())
        .WithAutomaticReconnect()
        .Build());
// Configure the app to use the SignalR client service
builder.Services.AddScoped(sp => sp.GetService<HubConnection>());

await builder.Build().RunAsync();
