using System;
using Japper.Profiles;

namespace Japper;

public class Japper
{
    public void zamazingo(){
        var dum = new dummy();
        ProfileCreator.NewProfile("Something", "sampleJson")
            .MapField("naber").To(typeof(int))
            .MapField("zaza").To(typeof(string))
            .Build();
    }
}
