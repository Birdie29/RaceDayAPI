using Microsoft.EntityFrameworkCore;
using RaceDayAPI.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

builder.Services.AddOpenApi();

var app = builder.Build();
builder.Services.AddDbContext<RaceDayContext>(options => options.UseSqlServer (
    builder.Configuration.GetConnectionString("DefaultConnection")));


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSession();

app.UseAuthorization();

app.MapControllers();

app.Run();
