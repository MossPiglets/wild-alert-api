using MediatR;

namespace WildAlert.Application.Requests.Sensors.Commands.DeleteSensor;

public class DeleteSensorCommand : IRequest
{
    public Guid Id { get; set; }
}