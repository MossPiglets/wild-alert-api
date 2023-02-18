using System.Net;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Application.Requests.SensorData.Commands.CreateSensorData;
using WildAlert.Application.Requests.SensorData.Queries.GetSensorData;
using WildAlert.Persistence.Entities.SensorData;

namespace WildAlert.Api.Controllers;


//[ServiceFilter((typeof(ApiKeyAuthFilter)))]
public class SensorDataController : Controller
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
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SensorDataEntity>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Index([FromQuery] GetSensorDataQuery query, CancellationToken token)
    {
        var sensorData = await _mediator.Send(query, token);
        return View(sensorData);
    }    
}