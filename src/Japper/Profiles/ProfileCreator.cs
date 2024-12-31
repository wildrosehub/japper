using System;
using Japper.Mapping;

namespace Japper.Profiles;

public class ProfileCreator
{
    private string _profileName;
    private string _jsonStructureName;
    public Dictionary<string, Type> Properties = [];
    public ProfileCreator(string profileName, string jsonStructureName){
        _profileName = profileName;
        _jsonStructureName = jsonStructureName;
    }
    public static ProfileCreator NewProfile(string profileName, string jsonStructureName){
        return new ProfileCreator(profileName, jsonStructureName);
    }

    public FieldMapper MapField(string fieldName){
        return new FieldMapper(fieldName, this);
    }

    public ArrayMapper MapArray(string arrayName){
        return new ArrayMapper(arrayName);
    }
    
    public Profile Build(){
        return new Profile(_profileName, Properties, _jsonStructureName);
    }
}
