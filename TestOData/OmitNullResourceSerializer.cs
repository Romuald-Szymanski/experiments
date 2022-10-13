using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Formatter.Serialization;
using Microsoft.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Vocabularies;
using Microsoft.OData.UriParser;

namespace TestOData;

public sealed class OmitNullResourceSerializer : ODataResourceSerializer
{
    public OmitNullResourceSerializer(IODataSerializerProvider serializerProvider) : base(serializerProvider)
    {
    }

    public override ODataProperty CreateStructuralProperty(IEdmStructuralProperty structuralProperty, ResourceContext resourceContext)
    {
        Console.WriteLine($"CreateStructuralProperty for {structuralProperty.Name}");
        
        object propertyValue = resourceContext.GetPropertyValue(structuralProperty.Name);
        if (propertyValue == null)
        {
            return null;
        }

        return base.CreateStructuralProperty(structuralProperty, resourceContext);
    }

    public override ODataNestedResourceInfo CreateComplexNestedResourceInfo(IEdmStructuralProperty complexProperty,
        PathSelectItem pathSelectItem, ResourceContext resourceContext)
    {
        Console.WriteLine($"CreateComplexNestedResourceInfo for {complexProperty.Name}");

        
        object propertyValue = resourceContext.GetPropertyValue(complexProperty.Name);
        if (propertyValue == null)
        {
            return null;
        }

        if (complexProperty.Name.Equals("name"))
        {
            // EdmComplexType t = new EdmComplexType("TestOData.Model", "Renamed", isOpen: true, baseType:null, isAbstract:false);
        }
        
        return base.CreateComplexNestedResourceInfo(complexProperty, pathSelectItem, resourceContext);
    }

    public override ODataNestedResourceInfo
        CreateNavigationLink(IEdmNavigationProperty navigationProperty, ResourceContext resourceContext)
    {
        Console.WriteLine($"CreateNavigationLink for {navigationProperty.Name}");
        
        object propertyValue = resourceContext.GetPropertyValue(navigationProperty.Name);
        if (propertyValue == null)
        {
            return null;
        }
        
        return base.CreateNavigationLink(navigationProperty, resourceContext);
    }
}