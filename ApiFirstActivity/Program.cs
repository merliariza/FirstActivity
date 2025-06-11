using System.Reflection;
using ApiFirstActivity.Extensions;
using Infrastructure;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAutoMapper(Assembly.GetEntryAssembly());

// Add services to the container.
builder.Services.ConfigureCors();
builder.Services.AddAplicacionServices();
builder.Services.AddControllers();
builder.Services.AddCustomRateLimiter();

// Swagger configuration
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<FirstActivityDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("DefaultConnection")!;
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("CorsPolicy");
app.UseHttpsRedirection();
app.UseRateLimiter();
app.MapControllers();
app.Run();
