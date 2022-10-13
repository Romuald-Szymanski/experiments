using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;

namespace TestOData;

public sealed class IgnoreNullEntityPropertiesSerializer : ODataResourceSerializer
{
    public IgnoreNullEntityPropertiesSerializer(IODataSerializerProvider serializerProvider) : base(serializerProvider)
    {
    }

    public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
    {
        ODataProperty property = base.CreateStructuralProperty(structuralProperty, resourceContext);
        return property.Value != null ? property : null;
    }
}