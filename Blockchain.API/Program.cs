using BlockchainManager.Services;
using BlockchainManager.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBlockchainPayement, BlockchainPayement>();
builder.Services.AddScoped<IDeployContract, DeployContract>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.UseHttpsRedirection();

app.Run("http://0.0.0.0:5006");

