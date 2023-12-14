using Microsoft.AspNetCore.Mvc;

namespace ArtLite.Api.Controllers;

[ApiController]
[Route("error")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        return Problem();
    }
}
