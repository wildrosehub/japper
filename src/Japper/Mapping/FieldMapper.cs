using System;
using Japper.Profiles;

namespace Japper.Mapping;

public class FieldMapper
{
    private string _fieldName;
    private ProfileCreator _creator;
    public FieldMapper(string fieldName, ProfileCreator creator){
        _fieldName = fieldName;
        _creator = creator;
    }

    public void Next()
    {
        throw new NotImplementedException();
    }

    public ProfileCreator To(Type type)
    {
        _creator.Properties.Add(_fieldName, new (type));
        return _creator;
    }
}
