using AutoMapper;
using MeteoScanner.Api.Hubs;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.OpenApi.Models;
using MScanner.Data;
using MScanner.Repository;
using MScanner.Repository.Api;
using MScanner.Repository.Profiles;
using IConfigurationProvider = AutoMapper.IConfigurationProvider;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// Add DbContext and AutoMapper
builder.Services.AddDbContext<SensorDataContext>();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add repository
builder.Services.AddScoped<ISensorDataRepository, SensorDataRepository>();

//Add mapper
builder.Services.AddScoped<IMapper>(sp => new Mapper(sp.GetRequiredService<IConfigurationProvider>(), sp.GetService));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHub<SensorDataHub>("/sensorDataHub");

app.UseRouting();
app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();