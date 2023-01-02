using MediatR;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;

namespace WildAlert.Application.Requests.Alerts.Queries.GetQuery;

public class GetAlertsQueryHandler : IRequestHandler<GetAlertsQuery, IEnumerable<AlertDto>>
{
    private readonly ApplicationDbContext _context;

    public GetAlertsQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<AlertDto>> Handle(GetAlertsQuery query, CancellationToken cancellationToken)
    {
        const double radius = 0.016;
        return await _context.Alerts
            .Where(x => query.Latitude == null || query.Longitude == null ||
                        (x.Latitude < query.Latitude + radius && x.Latitude > query.Latitude - radius &&
                         x.Longitude < query.Longitude + radius && x.Longitude > query.Longitude - radius))
            .Select(alert => new AlertDto
            {
                Animal = alert.Animal,
                Comments = alert.Comments,
                CreatedAt = alert.CreatedAt,
                Latitude = alert.Latitude,
                Longitude = alert.Longitude,
                Id = alert.Id
            })
            .ToListAsync(cancellationToken);
    }
}