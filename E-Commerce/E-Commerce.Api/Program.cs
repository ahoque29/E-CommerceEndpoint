using E_Commerce.Api.Validators;
using E_Commerce.Common.DTOs;
using E_Commerce.DataAccess.DBContext;
using E_Commerce.DataAccess.Service;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration["ConnectionString"];
builder.Services.AddDbContext<Context>(opts => opts.UseSqlServer(connectionString));

builder.Services.AddScoped<ICreateValidator<OrderDto>, OrderValidator>();
builder.Services.AddScoped<ICreateService<OrderDto>, OrderService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();