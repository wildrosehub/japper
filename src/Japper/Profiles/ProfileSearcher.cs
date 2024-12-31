using System;

namespace Japper.Profiles;

public class ProfileSearcher
{
    public Dictionary<string,Profile> profiles = [];
    //Searchs for classes that has IProfile interface and collects them at startup to load.
    //get jsonStructureNames to cache structures

    public void Find(){
        //find Profile Extensions
        //profiles.Add("extName", new Profile());
    }
}
