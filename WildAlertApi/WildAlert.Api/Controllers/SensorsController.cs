using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Sensors.Commands.CreateSensor;
using WildAlert.Application.Requests.Sensors.Commands.DeleteSensor;
using WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;
using WildAlert.Application.Requests.Sensors.Queries.GetSensorsQuery;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Api.Controllers;

//[ServiceFilter((typeof(ApiKeyAuthFilter)))]
public class SensorsController : Controller
{
    private readonly IMediator _mediator;

    public SensorsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public async Task<IActionResult> Create(CreateSensorCommand request, [FromServices] IValidator<CreateSensorCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        var sensor = await _mediator.Send(request, token);
        return View(sensor);
    }

    public async Task<IActionResult> Delete([FromRoute]Guid id)
    {
        var command = new DeleteSensorCommand()
        {
            Id = id
        };

        await _mediator.Send(command);
        return RedirectToAction(nameof(Index));
    }
    
    
    public async Task<IActionResult> Edit([FromForm]Guid id, UpdateSensorCommand request, [FromServices] IValidator<UpdateSensorCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return BadRequest(this.ModelState);
        }

        request.Id = id;
        var sensor = await _mediator.Send(request, token);
        return View(sensor);
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SensorEntity>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Index([FromQuery] GetSensorsQuery query, CancellationToken token)
    {
        var sensors = await _mediator.Send(query, token);
        return View(sensors);
    }

}