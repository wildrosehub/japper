using System;
using Japper.Constants;

namespace Japper.Mapping;

public record class Property
{
    public Type PrimitiveType { get; protected set; }
    public int NestLevel {get; protected set;}
    public Dictionary<string, Property>? InnerProperties {get; set;}
    public Property(Type primitiveType, Dictionary<string, Property>? innerProperties = null, int nestLevel = 0){
        PrimitiveType = primitiveType;
        NestLevel = nestLevel;

        InnerProperties = innerProperties;

        if(primitiveType == typeof(Array) && innerProperties is not null)
            InnerProperties = new();
           
        
    }
}
