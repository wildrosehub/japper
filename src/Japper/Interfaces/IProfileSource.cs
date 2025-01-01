using System;
using Japper.Engine;
using Japper.Profiles;

namespace Japper.Interfaces;

public interface IProfileSource
{
    public Task<Profile> Map();
}
