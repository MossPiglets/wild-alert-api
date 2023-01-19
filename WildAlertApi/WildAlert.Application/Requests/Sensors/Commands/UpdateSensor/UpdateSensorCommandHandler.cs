using MapsterMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;

public class UpdateSensorCommandHandler : IRequestHandler<UpdateSensorCommand, SensorDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public UpdateSensorCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<SensorDto> Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
    {
        var sensorToUpdate = await _context.Sensors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (sensorToUpdate is null) throw new NotFoundException(typeof(SensorEntity), request.Id.ToString());

        _mapper.Map(request, sensorToUpdate);
        _context.Sensors.Update(sensorToUpdate);
        await _context.SaveChangesAsync(cancellationToken);

        var sensorDto = _mapper.Map<SensorDto>(sensorToUpdate);
        return sensorDto;
    }
}