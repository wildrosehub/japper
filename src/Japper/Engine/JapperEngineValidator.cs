using System;
using System.Collections;
using Japper.Interfaces.Engine;
using Japper.Mapping;
using Japper.Profiles;

namespace Japper.Engine;

public class JapperEngineValidator : IJapperEngineValidator
{
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

        KeyValuePair<string, Property> a = profile.Properties.FirstOrDefault(kvp => string.Equals(kvp.Key, fieldName, StringComparison.InvariantCulture) && kvp.Value.PrimitiveType == typeof(T));
        if (!a.Equals(default(KeyValuePair<string, Property>)))
        {
            throw new KeyNotFoundException("There is no such field with that type and name");
        }

        return a.Value;
    }
}
