using System;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Profiles;

namespace Japper.Profiles;

public class ProfileActivator : IProfileActivator
{
    private readonly IProfileEngineContext _context;
    private readonly IProfileSearcher _searcher;

    public ProfileActivator(IProfileEngineContext context, IProfileSearcher searcher)
    {
        _context = context;
        _searcher = searcher;
    }

    public async void MapProfiles()
    {
        IProfileSource?[] profileSources = _searcher.Search();

        foreach (IProfileSource? profileSource in profileSources)
        {
            if (profileSource is null) continue;

            Profile profile = await profileSource.Map();

            if (!_context.ContainsKey(profile.Name))
            {
                _context.AddProfile(profile);
            }
        }
    }
}
