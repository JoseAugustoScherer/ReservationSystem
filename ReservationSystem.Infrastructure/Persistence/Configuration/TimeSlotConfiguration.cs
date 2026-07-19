using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ReservationSystem.Domain.Entity;

namespace ReservationSystem.Infrastructure.Persistence.Configuration;

public class TimeSlotConfiguration : IEntityTypeConfiguration<TimeSlot>
{
    public void Configure(EntityTypeBuilder<TimeSlot> builder)
    {
        builder.ToTable("TimeSlots");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedOnAdd();
        
        builder.Property(x => x.Start)
            .IsRequired();
        builder.Property(x => x.End)
            .IsRequired();
        builder.Property(x => x.IsReserved)
            .IsRequired();
        builder.Property(x => x.RoomId)
            .IsRequired();
        
        // builder.HasOne(x => x.Room)
        //     .WithMany(x => x.TimeSlots)
        //     .HasForeignKey(x => x.RoomId);
    }
}