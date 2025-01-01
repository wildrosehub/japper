using System;
using System.Collections.Concurrent;
using System.Collections.Immutable;
using Japper.Interfaces.Engine;
using Japper.Profiles;

namespace Japper.Engine;

public class ProfileEngineContext : IProfileEngineContext
{
    internal ConcurrentDictionary<string, Profile> Profiles {get; set;}

    public bool AddProfile(Profile profile){
        return Profiles.TryAdd(profile.Name, profile);
    }

    public (Profile, bool) GetProfile(string profileName){
        bool okay = Profiles.TryGetValue(profileName, out Profile profile);
        if (profile is null) okay = false;
        return (profile!, okay);
    }

    public bool ContainsKey(string profileName){
        return Profiles.ContainsKey(profileName);
    }
}
