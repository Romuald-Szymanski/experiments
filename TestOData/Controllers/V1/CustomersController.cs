using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using TestOData.Model;
using TestOData.Service;

namespace TestOData.Controllers.V1;

[ODataRouteComponent("v1")]
public sealed class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    [EnableQuery]
    public IActionResult Get()
    {
        Customer[] customers = _customerService.GetCustomers().ToArray();
        return Ok(customers);
    }
    
    [HttpGet]
    [EnableQuery]
    public IActionResult Get(Int64 key)
    {
        Customer customer = _customerService.GetCustomers().First(c => c.Id == key);
        return Ok(customer);
    }

    public IActionResult GetDepartment(Int64 key)
    {
        Customer customer = _customerService.GetCustomers().First(c => c.Id == key);
        return Ok(customer.Department);
    }
}