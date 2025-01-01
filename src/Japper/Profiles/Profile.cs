using System;
using System.Text.Json.Nodes;
using Japper.Mapping;

namespace Japper.Profiles;

public class Profile
{
    public string Name {get; private set;}
    private string _jsonStructureName;
    internal readonly Dictionary<string,Property> Properties;

    public Profile(string profileName, Dictionary<string,Property> properties, string jsonStructureName){
        Properties = properties;
        Name = profileName;
        _jsonStructureName = jsonStructureName;
    }

    public void Get(string name){

    }

    public void GetFromStructure(string name, string structureName){

    }

}
