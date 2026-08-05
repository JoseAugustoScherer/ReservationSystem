using ReservationSystem.Application.Dto.Request.RoomRequest;
using ReservationSystem.Application.Dto.Response.Room;
using ReservationSystem.Application.ViewModel;

namespace ReservationSystem.Application.Interfaces.RoomInterfaces;

public interface IRoomService
{
    Task<ResponseViewModel<RoomResponse>> CreateRoomAsync(CreateRoomRequest request, CancellationToken cancellationToken = default);
}