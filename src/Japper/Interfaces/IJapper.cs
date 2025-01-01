using System;
using Japper.Engine;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Profiles;

namespace Japper.Interfaces;

public interface IJapper
{
    public IJapperEngine From<TProfile>(string json) where TProfile : IProfileSource;
}
