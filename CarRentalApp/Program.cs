using CarRentalApp.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<CarsRentalDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("CarRentalDb"));
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

// "Server=localhost;Port=5432;Database=CarsRentalDb;Username=postgres;Password="
// Npgsql.EntityFrameworkCore.PostgreSQL