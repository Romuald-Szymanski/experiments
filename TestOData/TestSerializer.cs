using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;

namespace TestOData;

public sealed class TestSerializer : ODataResourceSerializer
{
    public TestSerializer(IODataSerializerProvider serializerProvider) : base(serializerProvider)
    {
    }

    public override ODataNestedResourceInfo
        CreateNavigationLink(IEdmNavigationProperty navigationProperty, ResourceContext resourceContext)
    {
        Console.WriteLine($"***** TestSerializer.CreateNavigationLink for {navigationProperty.Name}");
        return base.CreateNavigationLink(navigationProperty, resourceContext);
    }
}