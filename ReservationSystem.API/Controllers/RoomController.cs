using Microsoft.AspNetCore.Mvc;
using ReservationSystem.Application.Dto.Request.RoomRequest;
using ReservationSystem.Application.Interfaces.RoomInterfaces;

namespace ReservationSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoomController (IRoomService roomService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateRoomAsync(CreateRoomRequest request,
        CancellationToken cancellationToken = default)
    {
        var result = await roomService.CreateRoomAsync(request, cancellationToken);
        
        return result.IsFailure ? StatusCode(result.StatusCode, result) : Created($"/room/{result.Value.RoomId}", result.Value);
    }
}