# Welcome to Japper
- The current implementation doesn't complete and solid, so it probably gonna break.

This tool designed to make mappings for json files with fluent api. It can cache too.
The caching is used to save frequently called mapped properties.
Upcoming features are

- Save your profiles with EfCore, treat them like objects.
- Finish options pattern and be able to choose different cache providers and methods and other options.
- Integration with ABP.IO's Extension Properties

## How To Use
Firstly, you have to call `UseJapper()` and `MapProfiles()` in your Application Startup file. 

To activate japper add
``` csharp
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.UseJapper();

var app = builder.Build();

// Map profiles at runtime
app.Services.MapProfiles();

app.Run();
```

### How To Create A Profile And Register?
Create seperate class and derive it from `IProfileSource`, do your mappings. It is automatically discovered in runtime when you call `MapProfiles();`
``` csharp
public class MyProfile : IProfileSource {

  //This method helps Japper to map your profile.
  public async Task<Profile> Map(){
    return ProfileCreator.NewProfile("profileName")
      .MapArray("arrayName")
        .MapField("arrayFieldName").To(typeof(int))
        .MapField("arrayFieldName").To(typeof(string))
        .Next()
      .MapField("fieldName").To(typeof(float))
      .Build();
  }
}
```

### How To Use In Your Code
Simply inject the `IJapper` to your class and do the following
``` csharp
public class MyService {
  private readonly IJapperEngine _japperEngine;

  public MyService(IJapper japper){
    _japperEngine = japper.From<MyProfile>(jsonFile);
  }

  public void DoSomething(){
    int valueFromJapper = _japperEngine.GetField<int>("fieldName");
  }
}
```

