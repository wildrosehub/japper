using System;

namespace Japper.Mapping;

public class ArrayMapper : IMapper
{
    private string _arrayName;

    public ArrayMapper(string arrayName){
        _arrayName = arrayName;
    }
    public void Each()
    {
        throw new NotImplementedException();
    }

    public void Next()
    {
        throw new NotImplementedException();
    }

    public void To()
    {
        throw new NotImplementedException();
    }
}
