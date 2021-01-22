using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Eml.Contracts;

namespace Eml.ConfigParser.Tests.Integration.NetCore
{
    public interface IConsumerClass : IDiDiscoverableTransient
    {
        MyCustomSettingsConfig MyCustomSettings { get; }
    }

    public class ConsumerClass : IConsumerClass
    {
        public MyCustomSettingsConfig MyCustomSettings { get; }

        public ConsumerClass(IConfigParserBase<MyCustomSettingsConfig, MyCustomSettingsConfigParser> myCustomSettingsConfigParser) //<- Dependency injection via the class constructor
        {
            MyCustomSettings = myCustomSettingsConfigParser.Value;  //<- retrieve value
        }
    }
}