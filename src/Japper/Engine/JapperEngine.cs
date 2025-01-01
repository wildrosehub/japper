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
    private JapperEngineValidations _validator;
    private JapperEngine(string json, Profile profile){
        _json = json;
        _profile = profile;
        node = JsonNode.Parse(json) ?? throw new ArgumentNullException("Supplied json is not in proper format.");

        _validator = new JapperEngineValidations();
    }
    public async Task<T> GetField<T>(string fieldName) {
        //"name:innername:moreinnername:0:omgsoinner"
        Property prop = _validator.FindFieldOrThrow<T>(_profile, fieldName);
        return JapperEngineMatcher.Match<T>(fieldName, ref prop, ref node);
    }
    public async Task<T[]> GetArray<T>(string arrayName){
        return new T[1];
    }
    public async Task<dynamic> Get(string name){
        return 0;
    }

    internal static IJapperEngine Create(string json, Profile profile){
        return new JapperEngine(json, profile);
    }
}
