using System;

namespace Japper.Mapping;

public class ObjectFieldMapper
{
    private string _objectFieldName;
    private ObjectMapper _objectMapper;

    public ObjectFieldMapper(string objectFieldName, ObjectMapper objectMapper){
        _objectFieldName = objectFieldName;
        _objectMapper = objectMapper;
    }

    public ObjectMapper To(Type type){
        int targetNest = _objectMapper.Property.NestLevel + 1;
        _objectMapper.Property.Properties?.Add(_objectFieldName, new (type, nestLevel: targetNest));
        return _objectMapper;
    }
}
