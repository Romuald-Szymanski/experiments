using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData.Edm;

namespace TestOData;

public sealed class IgnoreNullEntityPropertiesSerializerProvider : ODataSerializerProvider
{
    private readonly IgnoreNullEntityPropertiesSerializer _entityTypeSerializer;
    
    public IgnoreNullEntityPropertiesSerializerProvider(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        _entityTypeSerializer = new IgnoreNullEntityPropertiesSerializer(this);
    }

    public override IODataEdmTypeSerializer GetEdmTypeSerializer(IEdmTypeReference edmType)
    {
        if (edmType.Definition.TypeKind == EdmTypeKind.Entity || edmType.Definition.TypeKind == EdmTypeKind.Complex)
            return _entityTypeSerializer;

        return base.GetEdmTypeSerializer(edmType);
    }
}