using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;

namespace WildAlert.Application.Requests.SensorData.Queries.GetSensorData;

public class GetSensorDataQueryHandler : IRequestHandler<GetSensorDataQuery, IEnumerable<SensorDataDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public GetSensorDataQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SensorDataDto>> Handle(GetSensorDataQuery query, CancellationToken cancellationToken)
    {
        return await _context.SensorData
            .Select(sensorData => _mapper.Map<SensorDataDto>(sensorData))
            .ToListAsync(cancellationToken);
    }
}