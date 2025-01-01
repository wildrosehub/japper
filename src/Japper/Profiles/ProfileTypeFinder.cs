using System;
using System.Reflection;
using Japper.Interfaces.Profiles;

namespace Japper.Profiles;

public class ProfileTypeFinder : IProfileTypeFinder
{
    public IEnumerable<Type> FindDerivedTypes<TInterface>()
    {
        Assembly specificAssembly = Assembly.GetExecutingAssembly(); // Scan only current assembly
        IEnumerable<Type> derivedTypes = specificAssembly
            .GetTypes()
            .Where(type => typeof(TInterface).IsAssignableFrom(type) && type.IsClass && !type.IsAbstract);
            
        return derivedTypes;
    }
}
