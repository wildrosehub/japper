using System;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Profiles;

namespace Japper.Engine;

public class JapperEngine : IJapperEngine
{
    private string _json;
    private Profile _profile;
    private JapperEngine(string json, Profile profile){
        _json = json;
        _profile = profile;
    }
    public Task<T> GetField<T>(string fieldName){
        
    }
    public Task<T[]> GetArray<T>(string arrayName){

    }
    public Task<dynamic> Get(string name){

    }

    internal static IJapperEngine Create(string json, Profile profile){
        return new JapperEngine(json, profile);
    }
}
