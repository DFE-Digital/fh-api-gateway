using Ocelot.DependencyInjection;
using Ocelot.Middleware;

// ref: https://medium.com/aspnetrun/building-ocelot-api-gateway-microservices-with-asp-net-core-and-docker-container-13f96026e86c

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
        .AddJsonFile("ocelot.json", optional: false, reloadOnChange: true)
        .AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration);

var app = builder.Build();
await app.UseOcelot();

app.MapGet("/", () => "Api Gateway Running!");

app.Run();
