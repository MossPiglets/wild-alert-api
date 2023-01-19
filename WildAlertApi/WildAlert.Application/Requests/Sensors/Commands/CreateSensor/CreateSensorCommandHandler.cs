using MapsterMapper;
using MediatR;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;
using WildAlert.Shared.DateTimeProvider;

namespace WildAlert.Application.Requests.Sensors.Commands.CreateSensor;

public class CreateSensorCommandHandler : IRequestHandler<CreateSensorCommand, SensorDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDateTimeProvider _dateTimeProvider;
    
    public CreateSensorCommandHandler(ApplicationDbContext context, IMapper mapper, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _mapper = mapper;
        _dateTimeProvider = dateTimeProvider;
    }
    
    public async Task<SensorDto> Handle(CreateSensorCommand request, CancellationToken cancellationToken)
    {
        SensorEntity sensorEntity = _mapper.Map<SensorEntity>(request);
        sensorEntity.Id = Guid.NewGuid();

        _context.Sensors.Add(sensorEntity); 
        await _context.SaveChangesAsync(cancellationToken);

        var sensorDto = _mapper.Map<SensorDto>(sensorEntity);
        return sensorDto;
    }
}