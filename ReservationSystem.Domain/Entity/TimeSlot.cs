using ReservationSystem.Domain.Entity.Base;

namespace ReservationSystem.Domain.Entity;

public class TimeSlot : BaseEntity
{
    public Guid RoomId { get; private set; }
    public Room Room { get; private set; }
    public bool IsReserved { get; private set; } = false;
    public DateTime Start { get; private set; }
    public DateTime End { get; private set; }
    
    // EF Ctor
    private TimeSlot(){}
    
    // Primary Ctor
    private TimeSlot(Guid roomId, DateTime start, DateTime end)
    {
        ValidDate(start, end);
        (RoomId, Start, End) = (roomId, start, end);
    }
    
    // Factory
    public static TimeSlot Create(Guid roomId, DateTime start, DateTime end)
     => new (roomId, start, end); 
    
    // Class Methods
    public void Reserve()
    {
        if (IsReserved)
            throw new InvalidOperationException("Time Slot already reserved");
        IsReserved = true;
    }
    
    public void UnReserve()
    {
        if (!IsReserved)
            throw new InvalidOperationException("Time Slot is not reserved");
        IsReserved = false;
    }

    private static void ValidDate(DateTime start, DateTime end)
    {
        if (start > end)
            throw new ArgumentException("Start date must be before end date");
    }
}