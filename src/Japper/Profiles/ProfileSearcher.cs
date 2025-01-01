using System;
using Japper.Interfaces;
using Japper.Interfaces.Engine;

namespace Japper.Profiles;

public class ProfileSearcher : IProfileSearcher
{
    private readonly IProfileEngineContext _context;

    public ProfileSearcher(IProfileEngineContext context){
        _context = context;
    }
    public Dictionary<string,Profile> profiles = [];
    //Searchs for classes that has IProfile interface and collects them at startup to load.
    //get jsonStructureNames to cache structures

    public void Search(){
        //find and call Map and add outputs to context
        //profile's name is the class's name where it is implemented
        var prof = new Profile();
        _context.AddProfile(prof);
        //find Profile Extensions
        //profiles.Add("extName", new Profile());
    }
}
