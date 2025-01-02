using System.Text;

namespace Japper.Cache;

public record PropertyCacheKey
{
    public string ProfileName {get; private set;}
    public string FieldName {get; private set;}
    public Type PropertyType {get; private set;}

    public PropertyCacheKey(string profileName, string fieldName, Type propertyType){
        ProfileName = profileName;
        FieldName = fieldName;
        PropertyType = propertyType;
    }

    public string GenerateCompositeKey(){
        return $"{ProfileName}:{FieldName}:{nameof(PropertyType)}";
    }
}
