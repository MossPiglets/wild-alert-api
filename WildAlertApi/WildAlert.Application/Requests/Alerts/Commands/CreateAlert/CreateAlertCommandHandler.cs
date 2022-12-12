using MediatR;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alert;

namespace WildAlert.Application.Requests.Alerts.Commands.CreateAlert;

public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, AlertDto>
{
    private readonly ApplicationDbContext _context;

    public CreateAlertCommandHandler(ApplicationDbContext context)
    {
        _context = context;
    }
    
    public async Task<AlertDto> Handle(CreateAlertCommand request, CancellationToken cancellationToken)
    {
        AlertEntity alertEntity = new AlertEntity()
        {
            Animal = request.Animal,
            Comments = request.Comments,
            CreatedAt = DateTime.UtcNow,
            Latitude = request.Latitude,
            Longitude = request.Longitude,
            Id = Guid.NewGuid()
        };
        _context.Alerts.Add(alertEntity); 
        await _context.SaveChangesAsync(cancellationToken); 
        
        var alertDto = new AlertDto() { 
            Animal = alertEntity.Animal,
            Comments = alertEntity.Comments,
            CreatedAt = alertEntity.CreatedAt,
            Latitude = alertEntity.Latitude,
            Longitude = alertEntity.Longitude,
            Id = alertEntity.Id
        };
        return alertDto;
    }
}