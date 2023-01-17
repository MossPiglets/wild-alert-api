using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;

namespace WildAlert.Application.Requests.Alerts.Queries.GetQuery;

public class GetAlertsQueryHandler : IRequestHandler<GetAlertsQuery, IEnumerable<AlertDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;


    public GetAlertsQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<AlertDto>> Handle(GetAlertsQuery query, CancellationToken cancellationToken)
    {
        double radiusInDegrees = 0.008 * query.Radius;
        return await _context.Alerts
            .Where(x => query.Latitude == null || query.Longitude == null ||
                        (x.Latitude < query.Latitude + radiusInDegrees && x.Latitude > query.Latitude - radiusInDegrees &&
                         x.Longitude < query.Longitude + radiusInDegrees && x.Longitude > query.Longitude - radiusInDegrees))
            .Select(alert => _mapper.Map<AlertDto>(alert))
            .ToListAsync(cancellationToken);
    }
}