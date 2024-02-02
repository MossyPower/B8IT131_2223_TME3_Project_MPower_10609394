using Microsoft.EntityFrameworkCore;
using RugbyDataApi.Models;
using RugbyDataApi.Data;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration
    .GetConnectionString("RugbyDataApiDbConnection") ?? 
    throw new InvalidOperationException("Connection string 'RugbyDataApiDbConnection' not found.");

builder.Services.AddDbContext<RugbyDataDbContext>(options =>
    options.UseSqlite(connectionString));

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddLogging(logging =>
{
    logging.AddConsole();
});

var app = builder.Build();

// Add for SeedData at startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    SeedData.Initialize(services);
}

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