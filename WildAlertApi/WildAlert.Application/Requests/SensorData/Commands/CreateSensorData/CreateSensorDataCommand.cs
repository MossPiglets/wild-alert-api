using MediatR;
using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Application.Requests.SensorData.Commands.CreateSensorData;

public class CreateSensorDataCommand : IRequest<SensorDataDto>
{
    public Guid Id { get; set; }
    public Guid SensorId { get; set; }
    public DateTime DetectedAt { get; set; }    
    public AnimalType DetectedAnimal { get; set; }
}