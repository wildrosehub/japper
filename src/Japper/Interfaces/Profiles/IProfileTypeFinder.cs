using System;

namespace Japper.Interfaces.Profiles;

public interface IProfileTypeFinder
{
    public IEnumerable<Type> FindDerivedTypes<TInterface>();
}
