using System;
using System.Security.Cryptography;
using Japper.Engine;
using Japper.Interfaces;
using Japper.Interfaces.Profiles;
using Japper.Options;
using Japper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Japper;

public class dummy: IProfileSource
{

    public async Task<Profile> Map()
    {

        // new JapperOptions(
        //     UseRedis: true,
        //     HashAlgorithm: HashAlgorithmName.SHA3_256
        // )
        // asdasd.UseJapper(opts => {
        //     opts.UseRedis();
        //     opts.UseSHA512();
        //     opts.DisableCaching();
        // });
        //deneme.MapProfiles();
        return new Profile("", [], "");
    }
    //ServiceProvider deneme = new ServiceCollection().BuildServiceProvider();
}
