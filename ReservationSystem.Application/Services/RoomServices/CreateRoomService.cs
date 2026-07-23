using ReservationSystem.Application.Dto.Request.RoomRequest;
using ReservationSystem.Application.Dto.Response.Room;
using ReservationSystem.Application.Dto.Response.TimeSlot;
using ReservationSystem.Application.Interfaces.RoomInterfaces;
using ReservationSystem.Application.Validators.RoomValidator;
using ReservationSystem.Application.ViewModel;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Domain.Interfaces;

namespace ReservationSystem.Application.Services.RoomServices;

public class CreateRoomService (IRoomRepository roomRepository, IUnitOfWork unitOfWork) : ICreateRoom
{
    public async Task<ResponseViewModel<RoomResponse>> CreateRoomAsync(CreateRoomRequest request, CancellationToken cancellationToken = default)
    {
        var validationResult = await  new RoomCreateRequestValidator().ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var errors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            
            return ResponseViewModel<RoomResponse>.Fail(errors, 400);
        }
        
        var room = await roomRepository.GetRoomByNumberAsync(request.Number, cancellationToken);

        if (room is not null)
            return ResponseViewModel<RoomResponse>.Fail("Room already exists", 400);

        var newRoom = Room.Create(request.Number);

        await roomRepository.CreateAsync(newRoom, cancellationToken);
        
        await unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new RoomResponse(newRoom.Id, newRoom.Number, []);
        
        return ResponseViewModel<RoomResponse>.Ok(response);
    }
}