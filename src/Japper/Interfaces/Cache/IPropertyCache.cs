using System;
using Japper.Cache;

namespace Japper.Interfaces.Cache;

public interface IPropertyCache
{
    public void Set<T>(PropertyCacheKey key, T value, TimeSpan exp);
    public bool TryGet<T>(PropertyCacheKey key, out T value);
    public void Remove(PropertyCacheKey key);
}
