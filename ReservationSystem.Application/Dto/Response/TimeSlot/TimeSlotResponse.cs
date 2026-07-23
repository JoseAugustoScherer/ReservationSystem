namespace ReservationSystem.Application.Dto.Response.TimeSlot;

public record TimeSlotResponse(Guid TimeSlotId, DateTime Start, DateTime End, bool IsReserved);