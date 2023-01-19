using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;

public class UpdateSensorCommandHandler : IRequestHandler<UpdateSensorCommand>
{
    private readonly ApplicationDbContext _context;

    public UpdateSensorCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<Unit> Handle(UpdateSensorCommand request, CancellationToken cancellationToken)
    {
        var sensorToUpdate = await _context.Sensors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (sensorToUpdate == null) throw new NotFoundException(typeof(SensorEntity), request.Id.ToString());

        _context.Sensors.Update(sensorToUpdate);

        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}