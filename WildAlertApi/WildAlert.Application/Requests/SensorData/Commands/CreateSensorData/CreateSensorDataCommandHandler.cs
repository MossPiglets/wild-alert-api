using MapsterMapper;
using MediatR;
using WildAlert.Application.Requests.Alerts;
using WildAlert.Application.Requests.Alerts.Commands.CreateAlert;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.Persistence.Entities.SensorData;
using WildAlert.Shared.DateTimeProvider;

namespace WildAlert.Application.Requests.SensorData.Commands.CreateSensorData;

public class CreateSensorDataCommandHandler : IRequestHandler<CreateSensorDataCommand, SensorDataDto>
{
   private readonly ApplicationDbContext _context;
   private readonly IMapper _mapper;
   private readonly IDateTimeProvider _dateTimeProvider;

   public CreateSensorDataCommandHandler(ApplicationDbContext context, IMapper mapper, IDateTimeProvider dateTimeProvider)
   {
      _context = context;
      _mapper = mapper;
      _dateTimeProvider = dateTimeProvider;
   }

   public async Task<SensorDataDto> Handle(CreateSensorDataCommand request, CancellationToken cancellationToken)
   {
      SensorDataEntity sensorDataEntity = _mapper.Map<SensorDataEntity>(request);
      //todo: czy w ogóle jest co mapować? czy powinny być różnice między entity a dto tutaj?
      _context.SensorData.Add(sensorDataEntity); 
      await _context.SaveChangesAsync(cancellationToken);

      var sensorDataDto = _mapper.Map<SensorDataDto>(sensorDataEntity);
      return sensorDataDto;
   }
}