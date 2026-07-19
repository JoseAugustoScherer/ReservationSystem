using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entity;

namespace ReservationSystem.Infrastructure.Persistence;

public class AppDbContext (DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Room> Rooms { get; set; }
    
    public DbSet<TimeSlot> TimeSlots { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}