using ReservationSystem.Domain.Entity.Base;

namespace ReservationSystem.Domain.Entity;

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
        if (TimeSlots.Any(t => t.Start == timeSlot.Start && t.End == timeSlot.End))
            throw new ArgumentException($"TimeSlot already exists with {timeSlot.Start} to {timeSlot.End}");
        
        TimeSlots.Add(timeSlot);
    }
}