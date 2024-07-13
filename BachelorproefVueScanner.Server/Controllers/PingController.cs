using Microsoft.AspNetCore.Mvc;

namespace BachelorproefVueScanner.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PingController : ControllerBase
{
    [HttpGet]
    public IActionResult GetPing()
    {
        return Ok(new { status = 200, message = "pong" });
    }
}
