using System;
using Japper.Profiles;

namespace Japper.Interfaces.Engine;

public interface IProfileEngineContext
{
    public bool AddProfile(Profile profile);
    public (Profile, bool) GetProfile(string profileName);
    public bool ContainsKey(string profileName);
}
