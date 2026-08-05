using ReservationSystem.Application.Dto.Request.TimeSlotRequest;
using ReservationSystem.Application.Dto.Response.TimeSlot;
using ReservationSystem.Application.Interfaces.TimeSlotInterfaces;
using ReservationSystem.Application.Validators.TimeSlotValidator;
using ReservationSystem.Application.ViewModel;
using ReservationSystem.Domain.Entities;
using ReservationSystem.Domain.Interfaces;

namespace ReservationSystem.Application.Services.TimeSlotServices;

public class TimeSlotService (IRoomRepository roomRepository, IUnitOfWork unitOfWork) : ITimeSlotService
{
    public async Task<ResponseViewModel<TimeSlotResponse>> CreateTimeSlotAsync(Guid roomId, CreateTimeSlotRequest request, CancellationToken cancellationToken = default)
    {
        var validationResult = await new TimeSlotCreateRequestValidator().ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            var erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            
            return ResponseViewModel<TimeSlotResponse>.Fail(erros, 400);
        }
        
        var room = await roomRepository.GetRoomWithTimeSlotsAsync(roomId, cancellationToken);
        
        if (room is null)
            return ResponseViewModel<TimeSlotResponse>.Fail("Room not found", 404);
        
        var newTimeSlot = TimeSlot.Create(roomId, request.Start, request.End);
        
        room.AddTimeSlot(newTimeSlot);

        await unitOfWork.SaveChangesAsync(cancellationToken);

        var response = new TimeSlotResponse(newTimeSlot.Id, request.Start, request.End, false);
        
        return ResponseViewModel<TimeSlotResponse>.Ok(response);
    }
}