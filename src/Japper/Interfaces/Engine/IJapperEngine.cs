using System;

namespace Japper.Interfaces.Engine;

public interface IJapperEngine
{
    public Task<T> GetField<T>(string fieldName);
    public Task<T[]> GetArray<T>(string arrayName);
    public Task<dynamic> Get(string name);
}
