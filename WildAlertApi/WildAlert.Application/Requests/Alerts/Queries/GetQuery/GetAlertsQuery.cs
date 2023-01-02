using MediatR;

namespace WildAlert.Application.Requests.Alerts.Queries.GetQuery;

public class GetAlertsQuery : IRequest<IEnumerable<AlertDto>>
{
    public double? Longitude { get; set; }
    public double? Latitude { get; set; }

    public double Radius { get; set; } = 2;
}