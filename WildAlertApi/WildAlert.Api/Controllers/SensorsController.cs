using System.Net;
using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Sensors.Commands.CreateSensor;
using WildAlert.Application.Requests.Sensors.Commands.DeleteSensor;
using WildAlert.Application.Requests.Sensors.Commands.UpdateSensor;
using WildAlert.Application.Requests.Sensors.Queries.GetSensorsQuery;
using WildAlert.Persistence;
using WildAlert.Persistence.Entities.Sensors;

namespace WildAlert.Api.Controllers;

//[ServiceFilter((typeof(ApiKeyAuthFilter)))]
public class SensorsController : Controller
{
    private readonly IMediator _mediator;
    private readonly ApplicationDbContext _context;

    public SensorsController(IMediator mediator, ApplicationDbContext context)
    {
        _mediator = mediator;
        _context = context;
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

        await _mediator.Send(request, token);
        return RedirectToAction(nameof(Index));
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

    public async Task<IActionResult> Edit([FromRoute] Guid id)
    {
        var sensor = await _context.Sensors.FirstOrDefaultAsync(x => x.Id == id);
        return View(sensor);
    }
    
    [HttpPost]
    public async Task<IActionResult> Edit([Bind("Id,Name,Longitude,Latitude")]UpdateSensorCommand request, [FromServices] IValidator<UpdateSensorCommand> validator, CancellationToken token)
    {
        ValidationResult result = await validator.ValidateAsync(request, token);
        
        if (!result.IsValid)
        {
            result.AddToModelState(this.ModelState);
            return RedirectToAction(nameof(Index));
        }

        var sensor = await _mediator.Send(request, token);
        return RedirectToAction(nameof(Index));
    }
    
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<SensorEntity>), (int) HttpStatusCode.OK)]
    public async Task<IActionResult> Index([FromQuery] GetSensorsQuery query, CancellationToken token)
    {
        var sensors = await _mediator.Send(query, token);
        return View(sensors);
    }

}