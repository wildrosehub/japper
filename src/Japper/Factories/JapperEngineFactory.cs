using System;
using Japper.Engine;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Factories;
using Japper.Profiles;

namespace Japper.Factories;

public class JapperEngineFactory : IJapperEngineFactory
{
    private readonly IJapperEngineValidator _engineValidator;
    private readonly IJapperEngineMatcher _engineMatcher;

    public JapperEngineFactory(IJapperEngineValidator engineValidator, IJapperEngineMatcher engineMatcher)
    {
        _engineValidator = engineValidator;
        _engineMatcher = engineMatcher;
    }
    public IJapperEngine Create(string json, Profile profile)
    {
        return new JapperEngine(json, profile, _engineMatcher, _engineValidator);
    }
}
