using MediatR;
using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Application.Requests.Alerts.Commands.CreateAlert;

public class CreateAlertCommand : IRequest<AlertDto>
{
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
    public string? Comments { get; set; }
    public AnimalType Animal { get; set; }
}