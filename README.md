# [Eml.ConfigParser](https://www.nuget.org/packages/Eml.ConfigParser/)
Use strongly-typed values from: 
* [appsettings.json](Tests/Eml.ConfigParser.Tests.Integration.NetCore/appsettings.json) or any other config.json files. Supports List of Native Types and accepts CustomParsers for complex types.
* .Net5 is now supported.
* Breaking changes: *Support to lower versions of .Net framework has been removed.* You need to upgrade to .Net5 or higher.

## Getting Started
Edit your .csproj and set your *.json files to CopyToOutputDirectory. 
```xml
<ItemGroup>
    <None Update="appsettings.json">
        <CopyToOutputDirectory>PreserveNewest</CopyToOutputDirectory>
    </None>
</ItemGroup>
```  

## Sample Config Classes
Create a class with a name that ends with **ConfigParser** and inherit from *ConfigParserBase\<T\>* where **T** is a native type or List of native types. 

#### 1. Uri
```javascript
public class ServiceUrlConfigParser : ConfigParserBase<Uri, ServiceUrlConfigParser>
{
    /// <summary>
    /// DI signature: <![CDATA[IConfigParserBase<Uri, ServiceUrlConfigParser> serviceUrlConfigParser]]>.
    /// </summary>
    public ServiceUrlConfigParser(IConfiguration configuration) : base(configuration)
    {
    }
}
 ```
#### 2. Connectionstrings
For connectionstrings, postfix a class with **ConnectionStringParser** otherwise, ***MissingSettingException*** will occur. 
```javascript
public class DefaultConnectionStringParser : ConfigParserBase<string, DefaultConnectionStringParser>
{
    /// <summary>
    /// DI signature: <![CDATA[IConfigParserBase<string, DefaultConnectionStringParser> defaultConnectionStringParser]]>.
    /// </summary>
    public DefaultConnectionStringParser(IConfiguration configuration)
        : base(configuration)
    {
    }
}
 ```
#### 3. Complex object
 * Sometimes you want to place configurations in one place, to elliminate the need for multiple ConfigParser classes. The example below will allow you to do just that. Take note of the ***new ComplexTypeConfigParser***\<MyComplexClass\>().
```javascript
public class MyComplexClassConfigParser : ConfigParserBase<MyComplexClass, MyComplexClassConfigParser>
{
    /// <summary>
    /// DI signature: <![CDATA[IConfigParserBase<MyComplexClass, MyComplexClassConfigParser> myComplexClassConfigParser]]>.
    /// </summary>
    public MyComplexClassConfigParser(IConfiguration configuration)
        : base(configuration, new ComplexTypeConfigParser<MyComplexClass>())
    {
    }
}
```
Sample custom class that will used to house multiple configurations:
* Properties here should **match the entries in your [appsettings.json](Tests/Eml.ConfigParser.Tests.Integration.NetCore/appsettings.json)** file.

```
public class MyComplexClass
{
    public string StringSetting { get; set; }
    public int IntSetting { get; set; }
    public Dictionary<string, InnerClass> Dictionary { get; set; }
    public List<string> ListOfValues { get; set; }
    public MyEnum AnEnum { get; set; }
}
```
#### 4. Lists
* Sample config parser for **List<>**.
```javascript
public class WhiteListConfigParser : ConfigParserBase<List<string>, WhiteListConfigParser>
{
    /// <summary>
    /// DI signature: <![CDATA[IConfigParserBase<List<string>, WhiteListConfigParser> whiteListConfigParser]]>.
    /// </summary>
    public WhiteListConfigParser(IConfiguration configuration) : base(configuration)
    {
    }
}
```

#### 5. string
* Sample config parser for **string** *(or any other native types such as int, bool, etc..)*.
```javascript
public class AppTitleParser : ConfigParserBase<string, AppTitleParser>
{
    /// <summary>
    /// DI signature: <![CDATA[IConfigParserBase<string, AppTitleParser> appTitleParser]]>.
    /// </summary>
    public AppTitleParser(IConfiguration configuration) : base(configuration)
    {
    }
}
```

##
More sample configs **[here](https://github.com/EddLonzanida/Eml.ConfigParser.Demo/tree/master/Tests/Eml.ConfigParser.Tests.Integration.NetCore/Configurations)**.
##
   
## Usage
### 1. [appsettings.json](Tests/Eml.ConfigParser.Tests.Integration.NetCore/appsettings.json) 
Sample:
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
### 2.a *Option 1* - Instantiate ServiceUrlConfigParser - *Manually*
* Startup.cs
```javascript
public Startup(IConfiguration configuration, ILoggerFactory loggerFactory)
{
    var serviceUrlConfigParser = new ServiceUrlConfigParser(configuration);
    var serviceUrlConfigParserValue = serviceUrlConfigParser.Value;     // retrieve value
}
```

### 2.b *Option 2* - DI registration via *IServiceCollection*
* Requires [Scrutor](https://github.com/khellang/Scrutor) for the automated registration.

* See **[IntegrationTestDiFixture.cs](Tests/Eml.ConfigParser.Tests.Integration.NetCore/BaseClasses/IntegrationTestDiFixture.cs)** for more details.

```javascript
    private static void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton(Configuration); // Register IConfiguration instance. Note: This is for manual registration of IConfiguration, Asp.Net will automtically do this for you. 
        services.Scan(scan => scan
            .FromAssemblyOf<IntegrationTestBase>()

                // Register ConfigParsers
                .AddClasses(classes => classes.AssignableTo<IConfigParserBase>())
                .AsSelfWithInterfaces()
                .WithScopedLifetime()
        );
    }
```
##
* Inject using DI signature: **IConfigParserBase<Uri, ServiceUrlConfigParser> serviceUrlConfigParser**
```javascript
public class ConsumerClass 
{
    public ConsumerClass(IConfigParserBase<Uri, ServiceUrlConfigParser> serviceUrlConfigParser) 
    { 
        var serviceUrlConfigParserValue = serviceUrlConfigParser.Value; //retrieve value
    }
}
```
##
### That's it.

* Check out [Eml.ConfigParser.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.ConfigParser) to automate the steps above.

![](Art/Steps_v2.gif)