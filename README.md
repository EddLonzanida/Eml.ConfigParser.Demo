# [Eml.ConfigParser](https://preview.nuget.org/packages/Eml.ConfigParser/)
Use strongly-typed values from: 
* appsettings.json or any other config.json files - *.NetCore2.2* - supports List of Native Types and accepts CustomParsers for complex types.
* App.Config or Web.Config - *.NetFramework*

## Getting Started - *.NetCore2.2*
Edit your .csproj and set your *.json files to CopyToOutputDirectory. 
```xml
<ItemGroup>
    <None Update="appsettings.json">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
</ItemGroup>
```  

## Sample Config Class
Create a class with a name that ends with **Config** and inherit from *ConfigBase\<T\>* where **T** is a native type or List of native types. 
```javascript
public class ServiceUrlConfig : ConfigBase<Uri, ServiceUrlConfig>
{
    public ServiceUrlConfig(IConfiguration configuration)
        : base(configuration)
    {
    }
}
 ```
For connectionstrings, postfix a class with **ConnectionString** otherwise, ***MissingSettingException*** will occur. 
```javascript
public class DefaultConnectionString : ConfigBase<string, DefaultConnectionString>
{
    public DefaultConnectionString(IConfiguration configuration)
        : base(configuration)
    {
    }
}
 ```
 
Refer [here](https://github.com/EddLonzanida/Eml.ConfigParser.Demo/blob/master/Tests/Eml.ConfigParser.Tests.Integration.NetCore/ComplexClass/MyComplexClass.cs) for complex type sample.

More sample configs [here](https://github.com/EddLonzanida/Eml.ConfigParser.Demo/tree/master/Tests/Eml.ConfigParser.Tests.Integration.NetCore/Configurations).
   
## Usage
### 1. json entry 
```javascript  
{
    "ConnectionStrings": {
        "DefaultConnectionString": "Server=.;Database=TestDb;Trusted_Connection=True;MultipleActiveResultSets=true"
    },
    "IntellisenseCount": 15,
    "ServiceLocationUrl": "http://testSite.com/home",
    "Expiry": "00:30:00",
    "DueDate": "2009-05-08 14:40:52",
    "WhiteList": [ "Item1", "Item2" ],
    "UriList": [ "http://example.com", "https://localhost:44355/", "https://localhost:44379/" ],
    "NumericList": [ 1.1, 2.2 ],
    "MyComplexClass": {
        "StringSetting": "My Value",
        "IntSetting": 23,
        "AnEnum": "Lots",
        "ListOfValues": [ "Value1", "Value2" ],
        "Dictionary": {
            "FirstKey": {
                "Name": "First Class",
                "IsEnabled": false
            },
            "SecondKey": {
                "Name": "Second Class" //IsEnabled has a default value of True if omitted
            },
            "ThirdKey": {
                "Name": "Third Class",
                "IsEnabled": true
            }
        }
    }
}
```
### 2.1 Instantiate ServiceUrlConfig - *Manually*
* Startup.cs
```javascript
var serviceUrlConfig = new ServiceUrlConfig(configuration);
```

### 2.2 Or add to DI container and register - via *IServiceCollection*
* Startup.cs
```javascript
public void ConfigureServices(IServiceCollection services)
{
    services.AddSingleton<IConfiguration>(configuration); 
    services.AddSingleton<ServiceUrlConfig>();
}
```

### 2.3 Or add to DI container and register - via *[Mef Bootstrapper](https://preview.nuget.org/packages/Eml.MefBootstrapper/)*
* Startup.cs
```javascript
public IConfiguration Configuration { get; private set; }
public static IClassFactory ClassFactory { get; private set; }
public static ILoggerFactory LoggerFactory { get; private set; }

public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
{
    Configuration = configuration;
    LoggerFactory = loggerFactory;
}

public void ConfigureServices(IServiceCollection services)
{
    ClassFactory = services.AddMef(() =>
    {
        // Register instances as shared.
        var instanceRegistrations = new List<Func<ContainerConfiguration, ExportDescriptorProvider>>
        {
            r => r.WithInstance(LoggerFactory),
            r => r.WithInstance(Configuration)
        };

        // Return IClassFactory
        return Bootstrapper.Init(API_NAME, instanceRegistrations);
    });
}
```

```javascript
[Export]
public class ConsumerClass 
{
    [ImportingConstructor]
    public ConsumerClass(ServiceUrlConfig serviceUrlConfig) { 
        var serviceUrlConfigValue = serviceUrlConfig.Value; //retrieve value
    }
}
```
More DI sample [here](https://github.com/EddLonzanida/Eml.ConfigParser.Demo/blob/master/Tests/Eml.ConfigParser.Tests.Integration.NetCore/WhenAConfigIsInDiContainer.cs).


More sample usage [here](https://github.com/EddLonzanida/Eml.ConfigParser.Demo/blob/master/Tests/Eml.ConfigParser.Tests.Integration.NetCore/WhenConfigIsPresent.cs).

##  

## Getting Started - *.NetFramework*

## Sample Config Class
Create a class with a name that ends with **Config** and inherit from *ConfigBase\<T\>* where **T** is a native type. 
```javascript
public class ServiceUrlConfig :  ConfigBase<Uri, ServiceUrlConfig>
{
}
 ```
For connectionstrings, postfix a class with **ConnectionString** otherwise, ***MissingSettingException*** will occur. 
```javascript
public class DefaultConnectionString : ConfigBase<string, DefaultConnectionString>
{
}
 ```
###
## Usage
### 1. App.config or Web.config entry
```xml
<?xml version="1.0" encoding="utf-8"?>
<configuration>
    <connectionStrings>
        <add name="DefaultConnectionString" connectionString="Data Source=.;Initial Catalog=TestDb;Integrated Security=True" providerName="System.Data.SqlClient" />
    </connectionStrings>
    <appSettings>
        <add key="IntellisenseCount" value="15" />
        <add key="ServiceUri" value="http://testSite.com/home" />
        <add key="Expiry" value="00:30:00" />
        <add key="DueDate" value="2010-06-07 14:40:51" />
    </appSettings>
</configuration>
 ``` 
### 2. Instantiate ServiceUriConfig - *Manually*
```javascript
var serviceUrlConfig = new ServiceUrlConfig(configuration);
var serviceUrlConfigValue = serviceUrlConfig.Value;         //retrieve value
```

### 3. Or add to DI container and load - via *[Mef Bootstrapper](https://preview.nuget.org/packages/Eml.MefBootstrapper/)*
* Global.asax.cs
```javascript
protected void Application_Start(){
    var classFactory = Bootstrapper.Init(rootFolder, new[] { "SearchPattern*.dll" });   //DirectoryCatalog pattern
}
```
```javascript
using System.ComponentModel.Composition;

[Export]
[PartCreationPolicy(CreationPolicy.NonShared)]
public class ConsumerClass 
{
    [ImportingConstructor]
    public ConsumerClass(IConfigBase<Uri, ServiceUrlConfig> serviceUrlConfig) { 
        var serviceUrlConfigValue = serviceUrlConfig.Value;
    }
}
```
## That's it.

* Check out [EmlExtensions.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.EmlExtensions) to automate the creation of ConfigParser, Controllers, Seeders, and more!.