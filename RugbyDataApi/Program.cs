using Microsoft.EntityFrameworkCore;
using TodoApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration
    .GetConnectionString("RugbyDataApiDBConnection") ??
    throw new InvalidOperationException("Connection string 'RugbyDataApiDBConnection' not found");

builder.Services.AddDbContext<RugbyDataDbContext>(options =>
    options.UseSqlite(connectionString));

// Add Sports Radar Api service
builder.Services.AddHttpClient<SportRadarApiService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
