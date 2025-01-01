using System;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Factories;
using Japper.Profiles;

namespace Japper.Factories;

public class JapperEngineFactory : IJapperEngineFactory
{
    private readonly IJapperEngineValidations
    public JapperEngineFactory(){

    }
    public IJapperEngine Create(string json, Profile profile)
    {
        throw new NotImplementedException();
    }
}
