using TestOData.Model;

namespace TestOData.Service;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers();
}