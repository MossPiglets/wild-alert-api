using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Authentication;
using WildAlert.Api.Authorization;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Sensors.Commands.CreateSensor;
using WildAlert.Application.Requests.Sensors.Commands.DeleteSensor;
using WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;
using WildAlert.Application.Requests.Sensors.Queries.GetSensorsQuery;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Api.Controllers;

[ApiController]
[ServiceFilter((typeof(ApiKeyAuthFilter)))]
[Route("api/[controller]")]
public class SensorsController : ControllerBase
{
    private readonly IMediator _mediator;

    public SensorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Post(CreateSensorCommand request, [FromServices] IValidator<CreateSensorCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        var sensor = await _mediator.Send(request, token);
        return Ok(sensor);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteSensorCommand()
        {
            Id = id
        };

        await _mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Put(Guid id, UpdateSensorCommand request, [FromServices] IValidator<UpdateSensorCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        request.Id = id;
        var sensor = await _mediator.Send(request, token);
        return Ok(sensor);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SensorEntity>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Get([FromQuery] GetSensorsQuery query, CancellationToken token)
    {
        var sensors = await _mediator.Send(query, token);
        return Ok(sensors);
    }
}