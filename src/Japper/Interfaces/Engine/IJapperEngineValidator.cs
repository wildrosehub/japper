using System;
using Japper.Mapping;
using Japper.Profiles;

namespace Japper.Interfaces.Engine;

public interface IJapperEngineValidator
{
    public bool IsField<T>();
    public bool IsArray<T>();
    public Property FindFieldOrThrow<T>(Profile profile, string fieldName);
}
