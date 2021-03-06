# [Eml.ConfigParser](https://www.nuget.org/packages/Eml.ConfigParser/)

* IoC/DI compatible.
* Has own [Visual Studio Addin](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.ConfigParser) for easier use.
* Small size.
* Read strongly-typed values from your [appsettings.json](Tests/Eml.ConfigParser.Tests.Integration.NetCore/appsettings.json) or any other config.json files.
* Supports List of Native Types and accepts Custom Classes for complex settings.
* .Net5 is now supported.

    **Breaking changes:** Starting with [Eml.ConfigParser.5.0.0](https://www.nuget.org/packages/Eml.ConfigParser/5.0.0), support to lower versions of .Net framework *has been removed.* You need to upgrade to .Net5 or higher.
##
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

Sample custom class that will be used to house multiple configurations:
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
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton(configuration); // Register IConfiguration instance. Note: This is for manual registration of IConfiguration, Asp.Net will automatically do this for you. 
            services.Scan(scan => scan
                .FromApplicationDependencies()

                    // Register ConfigParsers
                    .AddClasses(classes => classes.AssignableTo<IConfigParserBase>())
                    .AsSelfWithInterfaces()
                    .WithScopedLifetime()

                    // IDiDiscoverableTransient
                    .AddClasses(classes => classes.AssignableTo(typeof(IDiDiscoverableTransient)))
                    .AsImplementedInterfaces()
                    .WithTransientLifetime()
            );
        }
```

### 3. Loading other config files: [custom-settings.json](Tests/Eml.ConfigParser.Tests.Integration.NetCore/custom-settings.json)

* See **[IntegrationTestDiFixture.cs](Tests/Eml.ConfigParser.Tests.Integration.NetCore/BaseClasses/IntegrationTestDiFixture.cs)** for more details.

Sample class constructor:

```javascript
        public IntegrationTestDiFixture()
        {
            const string CURRENT_ENVIRONMENT = "Development";   //<- this can be obtained from hostContext.HostingEnvironment.EnvironmentName

            Configuration = GetCustomConfiguration(CURRENT_ENVIRONMENT);

            var services = new ServiceCollection();

            services.RegisterServices(Configuration); //<- Register IConfigParserBase

            ServiceProvider = services.BuildServiceProvider();
        }
```

GetCustomConfiguration:

```javascript
        private static IConfiguration GetCustomConfiguration(string currentEnvironment)
        {
            const string CUSTOM_CONFIG_FILE = "custom-settings.json";

            var configuration = currentEnvironment.GetConfiguration(CUSTOM_CONFIG_FILE);    // <- Will search for files in the current directory. 

            return configuration;
        }

```

##
* Inject using DI signature: **IConfigParserBase<MyCustomSettingsConfig, MyCustomSettingsConfigParser> myCustomSettingsConfigParser**
```javascript
    public class ConsumerClass : IConsumerClass
    {
        public MyCustomSettingsConfig MyCustomSettings { get; }

        public ConsumerClass(IConfigParserBase<MyCustomSettingsConfig, MyCustomSettingsConfigParser> myCustomSettingsConfigParser) //<- Dependency injection via the class constructor
        {
            MyCustomSettings = myCustomSettingsConfigParser.Value;  //<- retrieve value
        }
    }
```

##
### That's it.

* Check out [Eml.ConfigParser.vsix](https://marketplace.visualstudio.com/items?itemName=eDuDeTification.ConfigParser) to automate the steps above.

![](Art/Steps_v2.gif)