using System;
using Japper.Constants;
using Japper.Profiles;

namespace Japper.Mapping;

public class ObjectMapper
{
    private string _objectName;
    private ProfileCreator _creator;
    public Property Property;
    public ObjectMapper(string objectName, ProfileCreator creator){
        _objectName = objectName;
        _creator = creator;

        Property = new(PropertyTypeEnum.Object);
    }

    public ObjectFieldMapper MapField(string fieldName){
        return new ObjectFieldMapper(fieldName, this);
    }

    public ProfileCreator Next(){
        _creator.Properties.Add(_objectName, Property);
        return _creator;
    }
}
