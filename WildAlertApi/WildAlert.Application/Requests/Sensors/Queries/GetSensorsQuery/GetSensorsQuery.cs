using MediatR;

namespace WildAlert.Application.Requests.Sensors.Queries.GetSensorsQuery;

public class GetSensorsQuery : IRequest<IEnumerable<SensorDto>> { }