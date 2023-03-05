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
builder.Services.AddSingleton(sp =>
{
    var configuration = new ConfigurationBuilder()
        .SetBasePath(builder.HostEnvironment.BaseAddress)
        .AddJsonFile("appsettings.json")
        .Build();

    return configuration;
});
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

var hubUrl = builder.Configuration.GetValue<string>("SensorDataHubUrl");

builder.Services.AddSingleton(sp =>
{
    var hubUrl = sp.GetService<IConfiguration>().GetValue<string>("SensorDataHubUrl");
    return new HubConnectionBuilder().WithUrl("http://localhost:7080/sensorDataHub").Build();
});

await builder.Build().RunAsync();
