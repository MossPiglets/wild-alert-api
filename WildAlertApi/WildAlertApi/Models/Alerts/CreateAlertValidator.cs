using FluentValidation;

namespace WildAlertApi.Models.Alerts;

public class CreateAlertValidator : AbstractValidator<CreateAlert>
{
    public CreateAlertValidator()
    {
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Comments).MaximumLength(1000);
    }
}