using System;

namespace Japper.Profiles;

public class Profile
{
    private string _profileName;
    private string _jsonStructureName;
    private readonly Dictionary<string,Type> _properties;

    public Profile(string profileName, Dictionary<string,Type> properties, string jsonStructureName){
        _properties = properties;
        _profileName = profileName;
        _jsonStructureName = jsonStructureName;
    }

    public void Get(string name){

    }

    public void GetFromStructure(string name, string structureName){

    }

}
