using System;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Factories;
using Japper.Interfaces.Profiles;
using Japper.Profiles;

namespace Japper.Engine;

public class JapperProvider : IJapper
{
    private readonly IProfileEngineContext _context;
    private readonly IJapperEngineFactory _engineFactory;
    public JapperProvider(IProfileEngineContext context, IJapperEngineFactory engineFactory)
    {
        _context = context;
        _engineFactory = engineFactory;
    }
    public IJapperEngine From<TProfile>(string json) where TProfile : IProfileSource
    {
        bool ok = _context.ContainsKey(nameof(TProfile));
        if (!ok) throw new ArgumentException("Can not find a profile with that name: {0}", nameof(TProfile));

        (Profile profile, bool success) = _context.GetProfile(nameof(TProfile));
        if (!success) throw new ArgumentException("Can not get profile from context with that name: {0}", nameof(TProfile));

        Console.WriteLine("{0} is the name of the profile", nameof(TProfile));
        return _engineFactory.Create(json, profile);
    }
}
