using JwtAuthenticationManager;
using JwtAuthenticationManager.Data;
using JwtAuthenticationManager.Repositories;
using JwtAuthenticationManager.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<AuthDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddControllers();
builder.Services.AddScoped<JwtTokenHandler>();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUserAccountsRepository, UserAccountsRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();

app.Run();
