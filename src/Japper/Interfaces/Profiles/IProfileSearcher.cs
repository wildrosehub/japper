using System;

namespace Japper.Interfaces.Profiles;

public interface IProfileSearcher
{
    public IProfileSource?[] Search();
}
