using MediatR;

namespace WildAlert.Application.Requests.Sensors.Commands.CreateSensor;

    public class CreateSensorCommand : IRequest<SensorDto>
    {
        public double Longitude { get; set; }    
        public double Latitude { get; set; }
        public string? Name { get; set; }
    }
