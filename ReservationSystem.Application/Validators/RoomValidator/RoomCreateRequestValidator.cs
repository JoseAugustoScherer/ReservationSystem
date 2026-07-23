using FluentValidation;
using ReservationSystem.Application.Dto.Request.RoomRequest;

namespace ReservationSystem.Application.Validators.RoomValidator;

public class RoomCreateRequestValidator : AbstractValidator<CreateRoomRequest>
{
    public RoomCreateRequestValidator()
    {
        RuleFor(x => x.Number)
            .GreaterThan(0)
            .NotEmpty()
            .WithMessage("Number must be greater than zero");
    }
}