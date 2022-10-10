using TestOData.Model;

namespace TestOData.Service;

public sealed class CustomerService : ICustomerService
{
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
                Name = "Sales"
            },
            Address = new Address
            {
                City = "Paris",
                Street = "rue de Paradis"
            },
            Dep = new DepartmentDTO
            {
                Name = "Sales"
            }
        };
        
        yield return new Customer
        {
            Id = 2,
            Name = "Bernard",
            FavoriteColor = Color.Red,
            Department = new Department
            {
                Id = 2,
                Name = "IT"
            },
            Address = new Address
            {
                City = "Lyon",
                Street = "rue de la Madelain"
            },
            Dep = new DepartmentDTO
            {
                Name = "IT"
            }
        };
        
        yield return new Customer
        {
            Id = 3,
            Name = "Charles",
            FavoriteColor = Color.White,
            Department = new Department
            {
                Id = 1,
                Name = "Sales"
            },
            Address = new Address
            {
                City = "Lille",
                Street = "rue de la clef"
            },
            Dep = new DepartmentDTO
            {
                Name = "Sales"
            }
        };
    }
}