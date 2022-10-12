using Microsoft.AspNetCore.Mvc;

namespace TestOData.Controllers;

[ApiController]
[Route("api/resources")]
public class ResourcesController : ControllerBase
{
    public const String GetContentEndpoint = "Resources.GetContentEndpoint";

    public ResourcesController()
    {
    }
    
    [HttpGet]
    [Route("content/{label}", Name = GetContentEndpoint)]
    public IActionResult Index(string label)
    {
        return Ok($"label is {label}");
    }
}