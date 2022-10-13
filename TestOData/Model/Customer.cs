using Microsoft.OData.ModelBuilder;

namespace TestOData.Model;

public sealed class Customer
{
    public Int64 Id { get; set; }
    public String Name { get; set; }
    public Int64? Age { get; set; }
    public Color FavoriteColor { get; set; }
    [AutoExpand]
    public Department Department { get; set; }
    [AutoExpand]
    public Address Address { get; set; }
    public CustomerType Types { get; set; }
    // public IDictionary<String, Object> Types { get; set; }
}