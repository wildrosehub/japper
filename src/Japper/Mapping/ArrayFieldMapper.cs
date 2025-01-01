using System;

namespace Japper.Mapping;

public class ArrayFieldMapper
{
    private string _fieldName;
    private ArrayMapper _arrayMapper;
    public ArrayFieldMapper(string fieldName, ArrayMapper arrayMapper){
        _fieldName = fieldName;
        _arrayMapper = arrayMapper;

        if(_arrayMapper.Property.InnerProperties is null){
            _arrayMapper.Property.InnerProperties = new ();
        }
    }

    public ArrayMapper To(Type type){
        int targetNest = _arrayMapper.Property.NestLevel + 1;
        _arrayMapper.Property.InnerProperties?.Add(_fieldName, new (type, nestLevel: targetNest));
        return _arrayMapper;
    }
}
