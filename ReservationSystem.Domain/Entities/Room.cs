using ReservationSystem.Domain.Entities.Base;

namespace ReservationSystem.Domain.Entities;

public class Room : BaseEntity
{
    public int Number { get; private set; }
    public List<TimeSlot> TimeSlots { get; private set; } = [];
    
    // EF Ctor
    private Room(){}
    
    // Primary Ctor
    private Room(int number)
        => Number = number;
    
    // Factory
    public static Room Create(int number)
     => new Room(number);
    
    // Class Methods
    public void AddTimeSlot(TimeSlot timeSlot)
    {
        if (TimeSlots.Any(t => !((timeSlot.End <= t.Start) || (t.End <= timeSlot.Start))))
            throw new ArgumentException($"TimeSlot conflicts with an existing reservation from {timeSlot.Start} to {timeSlot.End}");
        
        TimeSlots.Add(timeSlot);
    }
}