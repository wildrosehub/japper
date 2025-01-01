using System;
using Japper.Profiles;

namespace Japper;

public class Japper
{
    public void zamazingo(){
        var dum = new dummy();
        ProfileCreator.NewProfile("Something", "sampleJson")
            .MapArray("asdasd")
                .MapField("zaza").To(typeof(int))
                .MapField("topop").To(typeof(string))
                .Next()
            .MapField("tomtom").To(typeof(float))
            .Build();
    }
}
