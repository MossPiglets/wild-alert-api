using MediatR;
using MediatR.AspNet.Exceptions;
using Microsoft.EntityFrameworkCore;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Application.Requests.Alerts.Commands.DeleteAlert;

public class DeleteAlertCommandHandler : IRequestHandler<DeleteAlertCommand>
{
    private readonly ApplicationDbContext _context;
    
    public DeleteAlertCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Unit> Handle(DeleteAlertCommand request, CancellationToken cancellationToken)
    {
        var alertToRemove = await _context.Alerts
            .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken: cancellationToken);
        if (alertToRemove == null) throw new NotFoundException(typeof(AlertEntity), request.Id.ToString());
        
        _context.Alerts.Remove(alertToRemove);
        await _context.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}