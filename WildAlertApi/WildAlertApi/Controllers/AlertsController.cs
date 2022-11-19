using Microsoft.AspNetCore.Mvc;

namespace WildAlertApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AlertsController : ControllerBase
{
    private readonly ILogger<AlertsController> _logger;

    public AlertsController(ILogger<AlertsController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public IActionResult Post()
    {
        // dodanie do bazy
        return Ok();
    }
}