using MediatR;
using WildAlert.Persistence.Entities.Alerts;

namespace WildAlert.Application.Requests.SensorData.Queries.GetSensorData;

public class GetSensorDataQuery : IRequest<IEnumerable<SensorDataDto>>
{
    public Guid Id { get; set; }
    public DateTime DetectedAt { get; set; }    
    public AnimalType DetectedAnimal { get; set; }
}