using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("ocelot.json", false, true)
    .AddEnvironmentVariables();
builder.Services.AddOcelot();

var app = builder.Build();

app.UseOcelot().Wait();

app.Run("http://0.0.0.0:5000");