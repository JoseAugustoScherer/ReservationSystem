using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Interfaces;
using ReservationSystem.Infrastructure.Persistence;
using ReservationSystem.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Database
var connectionString = builder.Configuration.GetConnectionString("PostgreSQL");

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseNpgsql(connectionString, npgsqlOptions =>
    {
        npgsqlOptions.MigrationsAssembly("ReservationSystem.Infrastructure");
    });
});


// Add services to the container.
builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IRoomRepository, RoomRepository>();

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

app.Run();