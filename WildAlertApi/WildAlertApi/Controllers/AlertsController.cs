using Microsoft.AspNetCore.Mvc;
using WildAlertApi.Models.Alerts;

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
    public IActionResult Post(CreateAlert createAlert)
    {
        // dodanie do bazy
        // wstrzyknij applicationDBContext w konstruktorze tego kontrolera
        // stwórz nową instancję klasy alert na podstawie createdAlert 
        // dodaj nową instancję bazy używając dbcontextu
        // zrób save changes i zwróc instancję alertu w ok
        return Ok();
    }
}