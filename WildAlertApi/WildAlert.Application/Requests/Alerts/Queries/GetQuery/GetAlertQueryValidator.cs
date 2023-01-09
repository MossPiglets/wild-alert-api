using FluentValidation;

namespace WildAlert.Application.Requests.Alerts.Queries.GetQuery;

public class GetAlertQueryValidator : AbstractValidator<GetAlertsQuery>
{
    public GetAlertQueryValidator()
    {
        RuleFor(x => x.Latitude).InclusiveBetween(-90, 90);
        RuleFor(x => x.Longitude).InclusiveBetween(-180, 180);
        RuleFor(x => x.Radius).GreaterThan(0);
    }
}