using System;
using Japper.Engine;
using Japper.Interfaces.Engine;

namespace Japper.Interfaces;

public interface IJapper
{
    public IJapperEngine From<TProfile>(string json) where TProfile : IProfileSource;
}
