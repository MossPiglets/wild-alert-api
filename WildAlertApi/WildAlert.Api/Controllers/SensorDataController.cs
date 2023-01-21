using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Application.Requests.SensorData.Commands.CreateSensorData;

namespace WildAlert.Api.Controllers;

[ApiController]
[Route("api/sensors/{sensorId}/data")]
public class SensorDataController : ControllerBase
{
    private readonly IMediator _mediator;

    public SensorDataController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(CreateSensorDataCommand request, CancellationToken token)
    {
        var sensor = await _mediator.Send(request, token);
        return Ok(sensor);
    }
}