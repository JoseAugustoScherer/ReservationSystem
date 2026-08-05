using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.Dto.Request.TimeSlotRequest;
using ReservationSystem.Application.Interfaces.TimeSlotInterfaces;

namespace ReservationSystem.API.Controllers;

[ApiController]
[Route("api/rooms/{roomId:guid}/timeslots")]
public class TimeSlotController (ITimeSlotService timeSlotService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateTimeSlotAsync(Guid roomId, CreateTimeSlotRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await timeSlotService.CreateTimeSlotAsync(roomId, request, cancellationToken);
        
        return result.IsFailure ? StatusCode(result.StatusCode, result) : Created($"/timeSlot/{result.Value.TimeSlotId}", result.Value);
    }
}