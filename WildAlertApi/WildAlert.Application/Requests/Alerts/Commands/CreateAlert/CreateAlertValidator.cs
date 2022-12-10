using FluentValidation;

namespace WildAlert.Application.Requests.Alerts.Commands.CreateAlert;

public class CreateAlertValidator : AbstractValidator<CreateAlertCommand>
{
    public CreateAlertValidator()
    {
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Comments).MaximumLength(1000);
    }
}