using MapsterMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;

namespace WildAlert.Application.Requests.Sensors.Queries.GetSensorsQuery;

public class GetSensorsQueryHandler : IRequestHandler<GetSensorsQuery, IEnumerable<SensorDto>>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public GetSensorsQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SensorDto>> Handle(GetSensorsQuery query, CancellationToken cancellationToken)
    {
        return await _context.Sensors
            .Select(sensor => _mapper.Map<SensorDto>(sensor))
            .ToListAsync(cancellationToken);
    }
}