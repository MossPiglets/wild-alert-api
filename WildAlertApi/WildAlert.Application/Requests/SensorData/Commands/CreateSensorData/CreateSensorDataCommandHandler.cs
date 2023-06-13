using MapsterMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.SensorData;
using WildAlert.Persistence.Entities.Sensors;
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
      var sensorId = await _context.Sensors
         .FirstOrDefaultAsync(x => x.Id == request.SensorId, cancellationToken: cancellationToken);
      if (sensorId is null) throw new NotFoundException(typeof(SensorEntity), request.SensorId.ToString());
      
      SensorDataEntity sensorDataEntity = _mapper.Map<SensorDataEntity>(request);
      sensorDataEntity.Id = Guid.NewGuid();
      sensorDataEntity.DetectedAt = _dateTimeProvider.UtcNow;

      _context.SensorData.Add(sensorDataEntity); 
      await _context.SaveChangesAsync(cancellationToken);

      var sensorDataDto = _mapper.Map<SensorDataDto>(sensorDataEntity);
      return sensorDataDto;
   }
}