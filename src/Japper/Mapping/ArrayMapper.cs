using System;
using Japper.Constants;
using Japper.Profiles;

namespace Japper.Mapping;

public class ArrayMapper
{
    private string _arrayName;
    private ProfileCreator _creator;
    public Property Property;

    public ArrayMapper(string arrayName, ProfileCreator profileCreator){
        _arrayName = arrayName;
        _creator = profileCreator;

        Property = new(PropertyTypeEnum.Array);
    }
    public ArrayFieldMapper MapField(string fieldName)
    {
        return new ArrayFieldMapper(fieldName, this);
    }

    public ProfileCreator Next()
    {
        _creator.Properties.Add(_arrayName, Property);
        return _creator;
    }

}
