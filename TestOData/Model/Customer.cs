namespace TestOData.Model;

public sealed class Customer
{
    public Int64 Id { get; set; }
    public String Name { get; set; }
    public Color FavoriteColor { get; set; }
    public Department Department { get; set; }
    public Address Address { get; set; }
}