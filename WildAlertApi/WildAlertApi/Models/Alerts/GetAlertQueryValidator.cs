using FluentValidation;

namespace WildAlertApi.Models.Alerts;

public class GetAlertQueryValidator : AbstractValidator<GetAlertsQuery>
{
    public GetAlertQueryValidator()
    {
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
    }
}