using ReservationSystem.Domain.Entities;
using ReservationSystem.Domain.Interfaces;
using ReservationSystem.Infrastructure.Persistence;

namespace ReservationSystem.Infrastructure.Repositories;

public class TimeSlotRepository (AppDbContext dbContext) : Repository<TimeSlot>(dbContext), ITimeSlotRepository
{
    
}