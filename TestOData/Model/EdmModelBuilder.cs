using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace TestOData.Model;

public static class EdmModelBuilder
{
    public static IEdmModel GetModelV1()
    { 
        ODataConventionModelBuilder builder = new();
        builder.EntitySet<Customer>("Customers");   // besoin d'un CustomersController
        // builder.EntitySet<Department>("Departments");
        builder.EnableLowerCamelCase();

        var eType = builder.AddEntityType(typeof(Department));
        eType.AddedExplicitly = false;
        
        return builder.GetEdmModel();
    }
}