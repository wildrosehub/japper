using System;
using System.Text.Json.Nodes;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Mapping;
using Japper.Profiles;

namespace Japper.Engine;

public class JapperEngine : IJapperEngine
{
    private string _json;
    private JsonNode node;
    private Profile _profile;
    private IJapperEngineValidator _validator;
    private IJapperEngineMatcher _matcher;
    internal JapperEngine(string json, Profile profile, IJapperEngineMatcher matcher, IJapperEngineValidator validator)
    {
        _json = json;
        _profile = profile;
        node = JsonNode.Parse(json) ?? throw new ArgumentNullException("Supplied json is not in proper format.");

        _validator = validator;
        _matcher = matcher;
    }
    public async Task<T> GetField<T>(string fieldName)
    {
        //"name:innername:moreinnername:0:omgsoinner"
        Property prop = _validator.FindFieldOrThrow<T>(_profile, fieldName); //we can add cache to here
        return _matcher.Match<T>(fieldName, ref prop, ref node); //we can add cache to here
    }
    public async Task<T[]> GetArray<T>(string arrayName)
    {
        throw new NotImplementedException();
    }
    public async Task<dynamic> Get(string name)
    {
        throw new NotImplementedException();
    }
}
