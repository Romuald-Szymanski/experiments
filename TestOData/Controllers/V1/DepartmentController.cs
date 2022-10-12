using Microsoft.AspNetCore.Mvc;
using TestOData.Model;

namespace TestOData.Controllers.V1;

[ApiController]
[Route("api/department")]
public class DepartmentController : ControllerBase
{
    private readonly LinkGenerator _linkGenerator;

    public DepartmentController(LinkGenerator linkGenerator)
    {
        _linkGenerator = linkGenerator;
    }
    
    [HttpGet]
    [Route("{id:int}")]
    public IActionResult Index(int id)
    {
        string name = _linkGenerator.GetUriByName(
            this.Request.HttpContext,
            ResourcesController.GetContentEndpoint,
            new { label = "department" });
        
        Department department = new()
        {
            Id = id,
            Name = name
        };
        return Ok(department);
    }
}