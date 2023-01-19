using MapsterMapper;
using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Application.Requests.Sensors.Commands.DeleteSensor;

public class DeleteSensorCommandHandler : IRequestHandler<DeleteSensorCommand>
{
    private readonly ApplicationDbContext _context;
    
    public DeleteSensorCommandHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteSensorCommand request, CancellationToken cancellationToken)
    {
        var sensorToRemove = await _context.Sensors
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (sensorToRemove == null) throw new NotFoundException(typeof(SensorEntity), request.Id.ToString());
        
        _context.Sensors.Remove(sensorToRemove);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
} 