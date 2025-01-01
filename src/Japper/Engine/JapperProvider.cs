using System;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Profiles;

namespace Japper.Engine;

public class JapperProvider : IJapper
{
    private readonly IProfileEngineContext _context;
    public JapperProvider(IProfileEngineContext context)
    {
        _context = context;
    }
    public IJapperEngine From<TProfile>(string json) where TProfile : IProfileSource
    {
        bool ok = _context.ContainsKey(nameof(TProfile));
        if (!ok) throw new ArgumentException("Can not find a profile with that name: {0}", nameof(TProfile));

        (Profile profile, bool success) = _context.GetProfile(nameof(TProfile));
        if (!success) throw new ArgumentException("Can not get profile from context with that name: {0}", nameof(TProfile));

        Console.WriteLine("{0} is the name of the profile", nameof(TProfile));
        return JapperEngine.Create(json, profile);
    }
}
