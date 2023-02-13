using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Authentication;
using WildAlert.Application.Requests.SensorData.Commands.CreateSensorData;

namespace WildAlert.Api.Controllers;

[ApiController]
[ServiceFilter((typeof(ApiKeyAuthFilter)))]
[Route("api/sensors/")]
public class SensorDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public SensorDataController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("{sensorId:guid}/data")]
    public async Task<IActionResult> Post(Guid sensorId, CreateSensorDataCommand request, CancellationToken token)
    {
        request.SensorId = sensorId;
        var sensor = await _mediator.Send(request, token);
        return Ok(sensor);
    }
}