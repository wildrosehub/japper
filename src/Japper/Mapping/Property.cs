using System;
using Japper.Constants;

namespace Japper.Mapping;

public record class Property
{
    public Type PrimitiveType { get; protected set; }
    public Dictionary<string, Property>? InnerProperties {get; set;}
    public Property(Type primitiveType, Dictionary<string, Property>? innerProperties = null){
        PrimitiveType = primitiveType;

        InnerProperties = innerProperties;

        if(primitiveType == typeof(Array) && innerProperties is not null)
            InnerProperties = new();
           
        
    }
}
