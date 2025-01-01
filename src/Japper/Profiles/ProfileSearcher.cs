using System;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Profiles;

namespace Japper.Profiles;

public class ProfileSearcher : IProfileSearcher
{
    private readonly IProfileEngineContext _context;
    private readonly IProfileTypeFinder _typeFinder;

    public ProfileSearcher(IProfileEngineContext context, IProfileTypeFinder typeFinder){
        _context = context;
        _typeFinder = typeFinder;
    }
    public Dictionary<string,Profile> profiles = [];
    //Searchs for classes that has IProfile interface and collects them at startup to load.
    //get jsonStructureNames to cache structures

    public IProfileSource?[] Search(){
        //find and call Map and add outputs to context
        //profile's name is the class's name where it is implemented
        IEnumerable<Type> types = _typeFinder.FindDerivedTypes<IProfileSource>();
        return types.Select(type => Activator.CreateInstance(type) as IProfileSource).ToArray();
    }
}
