using System;
using Japper.Constants;

namespace Japper.Mapping;

public record class Property
{
    public Type PrimitiveType { get; protected set; }
    public PropertyTypeEnum PropertyType;
    public int NestLevel {get; protected set;}
    public Dictionary<string, Property>? Properties {get; set;}
    public Property(PropertyTypeEnum propertyType, Dictionary<string, Property>? innerProperties = null, int nestLevel = 0){
        PropertyType = propertyType;
        NestLevel = nestLevel;

        Properties = innerProperties;

        if(PropertyType == PropertyTypeEnum.Array && innerProperties is not null)
            Properties = new();
           
        
    }
}
