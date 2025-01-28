using System;

namespace Japper.Mapping;

public class ArrayFieldMapper
{
    private string _fieldName;
    private ArrayMapper _arrayMapper;
    public ArrayFieldMapper(string fieldName, ArrayMapper arrayMapper){
        _fieldName = fieldName;
        _arrayMapper = arrayMapper;

        _arrayMapper.Property.Properties ??= [];
    }

    public ArrayMapper To(Type type){
        int targetNest = _arrayMapper.Property.NestLevel + 1;
        _arrayMapper.Property.Properties?.Add(_fieldName, new (type, nestLevel: targetNest));
        return _arrayMapper;
    }
}
