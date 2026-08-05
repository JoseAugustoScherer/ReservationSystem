using ReservationSystem.Application.Dto.Request.TimeSlotRequest;
using ReservationSystem.Application.Dto.Response.TimeSlot;
using ReservationSystem.Application.ViewModel;

namespace ReservationSystem.Application.Interfaces.TimeSlotInterfaces;

public interface ITimeSlotService
{
    Task<ResponseViewModel<TimeSlotResponse>> CreateTimeSlotAsync(Guid roomId, CreateTimeSlotRequest request, CancellationToken cancellationToken = default);
}