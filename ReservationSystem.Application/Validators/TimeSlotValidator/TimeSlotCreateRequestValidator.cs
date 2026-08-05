using FluentValidation;
using ReservationSystem.Application.Dto.Request.TimeSlotRequest;

namespace ReservationSystem.Application.Validators.TimeSlotValidator;

public class TimeSlotCreateRequestValidator : AbstractValidator<CreateTimeSlotRequest>
{
    public TimeSlotCreateRequestValidator()
    {
        RuleFor(x => x.End)
            .GreaterThan(x => x.Start)
            .WithMessage("End time must be greater than Start time.");
        
        RuleFor(x => x.Start)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Start time must be in the future.");
    }
}