using Microsoft.EntityFrameworkCore;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Domain.Interfaces;
using ReservationSystem.Infrastructure.Persistence;

namespace ReservationSystem.Infrastructure.Repositories;

public class RoomRepository (AppDbContext dbContext) : Repository<Room>(dbContext), IRoomRepository
{
    public async Task<Room?> GetRoomByNumberAsync(int number, CancellationToken cancellationToken = default)
    {
        if(number <= 0)
            throw new ArgumentException("Invalid room number", nameof(number));
        
        return await dbContext.Set<Room>().FirstOrDefaultAsync(x => x.Number == number, cancellationToken);
    }

    public async Task<Room?> GetRoomWithTimeSlotsAsync(Guid roomId, CancellationToken cancellationToken = default)
    {
        return await dbContext.Rooms
            .Include(x => x.TimeSlots)
            .FirstOrDefaultAsync(x => x.Id == roomId, cancellationToken);
    }
}