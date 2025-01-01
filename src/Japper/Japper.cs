using System;
using System.Linq.Expressions;
using Japper.Engine;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Options;
using Japper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Japper;

public static class Japper
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

            IJapper japper = new JapperProvider();

            japper.From<dummy>("jsonFile").GetField<int>("fieldName"); 
            var engine = japper.From<dummy>("");
            engine.GetField<int>("name");
    }

    public static IServiceCollection UseJapper(this IServiceCollection services, Action<JapperOptions> options){
        services.AddSingleton<IProfileEngineContext, ProfileEngineContext>();
        services.AddScoped<IJapper, JapperProvider>();
        return services;
    }
}
