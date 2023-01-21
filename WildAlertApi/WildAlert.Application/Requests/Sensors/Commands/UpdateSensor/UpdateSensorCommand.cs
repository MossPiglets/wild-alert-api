using System.Text.Json.Serialization;
using MediatR;

namespace WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;

public class UpdateSensorCommand : IRequest<SensorDto>
{
    [JsonIgnore]
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public double Longitude { get; set; }    
    public double Latitude { get; set; }
}