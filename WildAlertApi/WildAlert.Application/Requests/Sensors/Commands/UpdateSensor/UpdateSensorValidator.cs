using FluentValidation;

namespace WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;

public class UpdateSensorValidator : AbstractValidator<UpdateSensorCommand>
{
    public UpdateSensorValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        RuleFor(x => x.Latitude).NotEmpty().InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).NotEmpty().InclusiveBetween(-180, 180);
        RuleFor(x => x.Name).NotEmpty().MaximumLength(1000);
    }
}