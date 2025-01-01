using System;
using Japper.Interfaces.Engine;
using Japper.Profiles;

namespace Japper.Interfaces.Factories;

public interface IJapperEngineFactory
{
    public IJapperEngine Create(string json, Profile profile);
}
