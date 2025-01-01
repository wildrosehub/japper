using System;
using System.Linq.Expressions;
using Japper.Engine;
using Japper.Factories;
using Japper.Interfaces;
using Japper.Interfaces.Engine;
using Japper.Interfaces.Factories;
using Japper.Interfaces.Profiles;
using Japper.Options;
using Japper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Japper;

public static class Japper
{
    public static void zamazingo(){
        var dum = new dummy();
        ProfileCreator.NewProfile("Something", "sampleJson")
            .MapArray("asdasd")
                .MapField("zaza").To(typeof(int))
                .MapField("topop").To(typeof(string))
                .Next()
            .MapField("tomtom").To(typeof(float))
            .Build();

            
            IJapper japper = new JapperProvider(new ProfileEngineContext(), new JapperEngineFactory(new JapperEngineValidator(), new JapperEngineMatcher()));

            japper.From<dummy>("jsonFile").GetField<int>("fieldName"); 
            var engine = japper.From<dummy>("");
            engine.GetField<int>("name");
    }

    public static IServiceCollection UseJapper(this IServiceCollection services, Action<JapperOptions> options){
        services.AddSingleton<IJapperEngineFactory, JapperEngineFactory>();
        services.AddSingleton<IProfileEngineContext, ProfileEngineContext>();

        services.AddScoped<IJapperEngineMatcher, JapperEngineMatcher>();
        services.AddScoped<IJapperEngineValidator, JapperEngineValidator>();


        services.AddScoped<IJapper, JapperProvider>();

        //needs to be used just once in the start
        services.AddTransient<IProfileTypeFinder, ProfileTypeFinder>();
        services.AddTransient<IProfileSearcher, ProfileSearcher>();
        services.AddTransient<IProfileActivator, ProfileActivator>();
        return services;
    }
}
