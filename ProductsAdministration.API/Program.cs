using ProductsAdministration.BLL.Services;
using ProductsAdministration.BLL.Services.IServices;
using ProductsAdministration.DAL.Repositories;
using ProductsAdministration.DAL.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

//Repositories
builder.Services.AddScoped<IProductRepository, ProductRepository>();
//Services
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
