using System;
using System.Collections;
using Japper.Cache;
using Japper.Interfaces.Cache;
using Japper.Interfaces.Engine;
using Japper.Mapping;
using Japper.Profiles;

namespace Japper.Engine;

public class JapperEngineValidator : IJapperEngineValidator
{
    private readonly IPropertyCache _propertyCache;
    public JapperEngineValidator(IPropertyCache propertyCache){
        _propertyCache = propertyCache;
    }

    private bool isPrimitive<T>()
    {
        bool isInt = typeof(T) == typeof(int);
        bool isFloat = typeof(T) == typeof(float);
        bool isDecimal = typeof(T) == typeof(decimal);
        bool isBool = typeof(T) == typeof(bool);
        bool isDouble = typeof(T) == typeof(double);
        bool isByte = typeof(T) == typeof(byte);

        return isInt || isFloat || isDecimal || isBool || isDouble || isByte;
    }
    public bool IsField<T>()
    {
        return isPrimitive<T>();
    }
    public bool IsArray<T>()
    {
        return typeof(T) == typeof(Array);
    }

    public Property FindFieldOrThrow<T>(Profile profile, string fieldName)
    {
        if (!IsField<T>())
        {
            throw new KeyNotFoundException("Collections can not be found with field getter");
        }

        PropertyCacheKey cacheKey = new(profile.Name, fieldName, typeof(T));

        if(_propertyCache.TryGet(cacheKey, out Property prop)){
           return prop; 
        }

        KeyValuePair<string, Property> a = profile.Properties.FirstOrDefault(kvp => string.Equals(kvp.Key, fieldName, StringComparison.InvariantCulture) && kvp.Value.PrimitiveType == typeof(T));
        if (!a.Equals(default(KeyValuePair<string, Property>)))
        {
            throw new KeyNotFoundException("There is no such field with that type and name");
        }
        _propertyCache.Set(cacheKey, a.Value, TimeSpan.FromMinutes(10));

        return a.Value;
    }
}
