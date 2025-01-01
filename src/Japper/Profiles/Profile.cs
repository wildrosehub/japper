using System;
using Japper.Mapping;

namespace Japper.Profiles;

public class Profile
{
    public string Name {get; private set;}
    private string _jsonStructureName;
    private readonly Dictionary<string,Property> _properties;

    public Profile(string profileName, Dictionary<string,Property> properties, string jsonStructureName){
        _properties = properties;
        Name = profileName;
        _jsonStructureName = jsonStructureName;
    }

    public void Get(string name){

    }

    public void GetFromStructure(string name, string structureName){

    }

}
