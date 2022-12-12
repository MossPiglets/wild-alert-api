using MediatR;

namespace WildAlert.Application.Requests.Alerts.Queries.GetQuery;

public class GetAlertsQueryHandler : IRequestHandler<GetAlertsQuery, IEnumerable<AlertDto>>
{
    public Task<IEnumerable<AlertDto>> Handle(GetAlertsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}