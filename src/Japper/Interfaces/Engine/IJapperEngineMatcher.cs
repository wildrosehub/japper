using System;
using System.Text.Json.Nodes;
using Japper.Mapping;

namespace Japper.Interfaces.Engine;

public interface IJapperEngineMatcher
{
    public T Match<T>(string fieldName, ref Property prop, ref JsonNode node);
}
