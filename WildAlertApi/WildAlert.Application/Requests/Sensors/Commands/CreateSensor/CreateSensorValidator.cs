using FluentValidation;

namespace WildAlert.Application.Requests.Sensors.Commands.CreateSensor;

public class CreateSensorValidator : AbstractValidator<CreateSensorCommand>
{
    public CreateSensorValidator()
    {
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Name).MaximumLength(1000);
    }
}