using ReservationSystem.Domain.Entities;

namespace ReservationSystem.Domain.Interfaces;

public interface IRoomRepository : IBaseRepository<Room>
{
    Task<Room?> GetRoomByNumberAsync(int number, CancellationToken cancellationToken = default);
    Task<Room?> GetRoomWithTimeSlotsAsync(Guid roomId, CancellationToken cancellationToken = default);
}