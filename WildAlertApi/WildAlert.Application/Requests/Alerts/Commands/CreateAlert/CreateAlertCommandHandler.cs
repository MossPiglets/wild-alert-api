using MapsterMapper;
using MediatR;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Alerts;
using WildAlert.Shared.DateTimeProvider;

namespace WildAlert.Application.Requests.Alerts.Commands.CreateAlert;

public class CreateAlertCommandHandler : IRequestHandler<CreateAlertCommand, AlertDto>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;
    private readonly IDateTimeProvider _dateTimeProvider;

    public CreateAlertCommandHandler(ApplicationDbContext context, IMapper mapper, IDateTimeProvider dateTimeProvider)
    {
        _context = context;
        _mapper = mapper;
        _dateTimeProvider = dateTimeProvider;
    }
    
    public async Task<AlertDto> Handle(CreateAlertCommand request, CancellationToken cancellationToken)
    {
        AlertEntity alertEntity = _mapper.Map<AlertEntity>(request);
        alertEntity.CreatedAt = _dateTimeProvider.UtcNow;
        alertEntity.Id = Guid.NewGuid();

        _context.Alerts.Add(alertEntity); 
        await _context.SaveChangesAsync(cancellationToken);

        var alertDto = _mapper.Map<AlertDto>(alertEntity);
        return alertDto;
    }
}