using TestOData.Controllers;
using TestOData.Model;

namespace TestOData.Service;

public sealed class CustomerService : ICustomerService
{
    private readonly IHttpContextAccessor _context;
    private readonly LinkGenerator _linkGenerator;

    public CustomerService(IHttpContextAccessor context, LinkGenerator linkGenerator)
    {
        _context = context;
        _linkGenerator = linkGenerator;
    }
    
    public IEnumerable<Customer> GetCustomers()
    {
        yield return new Customer
        {
            Id = 1,
            Name = "Alain",
            FavoriteColor = Color.Blue,
            Department = new Department
            {
                Id = 1,
                Name = "Sales",
                Label = _linkGenerator.GetUriByName(_context.HttpContext, ResourcesController.GetContentEndpoint, new { label = "Sales" })
            },
            Address = new Address
            {
                City = "Paris",
                Street = "rue de Paradis"
            },
            Types = new CustomerType
            {
                TypesDictionary = new Dictionary<string, object>
                {
                    { "Type1", "Valeur1"},
                    { "Type2", "Valeur2"}
                }
            }
            // Types = new Dictionary<string, object>
            // {
            //     { "Type1", "Valeur1"},
            //     { "Type2", "Valeur2"}
            // }
        };
        
        yield break;

        yield return new Customer
        {
            Id = 2,
            Name = "Bernard",
            FavoriteColor = Color.Red,
            Department = new Department
            {
                Id = 2,
                Name = "IT",
                Label = _linkGenerator.GetUriByName(_context.HttpContext, ResourcesController.GetContentEndpoint, new { label = "IT" })
            },
            Address = new Address
            {
                City = "Lyon",
                Street = "rue de la Madelain"
            },
            Age = 25
        };
        
        yield return new Customer
        {
            Id = 3,
            Name = "Charles",
            FavoriteColor = Color.White,
            Department = new Department
            {
                Id = 1,
                Name = "Sales",
                Label = _linkGenerator.GetUriByName(_context.HttpContext, ResourcesController.GetContentEndpoint, new { label = "Sales" })
            }
        };
    }
}