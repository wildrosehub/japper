using System;
using System.Text.Json.Nodes;
using Japper.Interfaces.Engine;
using Japper.Mapping;

namespace Japper.Engine;

public class JapperEngineMatcher : IJapperEngineMatcher
{
    public T Match<T>(string fieldName, ref Property prop, ref JsonNode node){
        throw new NotImplementedException();
    }
}
