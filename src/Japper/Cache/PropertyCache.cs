using System;
using Japper.Interfaces.Cache;
using Microsoft.Extensions.Caching.Memory;

namespace Japper.Cache;

public class PropertyCache : IPropertyCache
{
    private readonly IMemoryCache _memoryCache;

    public PropertyCache(IMemoryCache memoryCache){
        _memoryCache = memoryCache;
    }
    public void Remove(PropertyCacheKey key)
    {
        _memoryCache.Remove(key.GenerateCompositeKey());
    }

    public void Set<T>(PropertyCacheKey key, T value, TimeSpan exp)
    {
        _memoryCache.Set(key.GenerateCompositeKey(), value, exp);
    }

    public bool TryGet<T>(PropertyCacheKey key, out T value)
    {
        return _memoryCache.TryGetValue(key.GenerateCompositeKey(), out value);
    }
}
