using Microsoft.AspNetCore.Mvc;

namespace Presentation.Home;

[Route("")]
[ApiController]
public class HomeController : ControllerBase
{
    public async Task<IActionResult> Index()
    {
        return Ok("API is working. Available routes: api/v1/weather/{city}, api/v1/weather/{latitude}/{longitude}");
    }
}