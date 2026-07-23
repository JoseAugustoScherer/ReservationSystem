using ReservationSystem.Application.Dto.Response.TimeSlot;

namespace ReservationSystem.Application.Dto.Response.Room;

public record RoomResponse(Guid RoomId, int Number, List<TimeSlotResponse> TimeSlots);