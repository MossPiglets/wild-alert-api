using FluentValidation;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WildAlert.Api.Extensions;
using WildAlert.Application.Requests.Sensors.Commands.CreateSensor;

namespace WildSensor.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SensorsController:ControllerBase
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
}