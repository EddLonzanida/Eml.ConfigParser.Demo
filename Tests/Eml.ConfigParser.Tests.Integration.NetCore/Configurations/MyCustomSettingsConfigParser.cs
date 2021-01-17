using Eml.ConfigParser.Parsers;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class MyCustomSettingsConfigParser : ConfigParserBase<MyCustomSettingsConfig, MyCustomSettingsConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigParserBase<MyCustomSettingsConfig, MyCustomSettingsConfigParser> myCustomSettingsConfigParser]]>.
        /// </summary>
        public MyCustomSettingsConfigParser(IConfiguration configuration)
            : base(configuration, new ComplexTypeConfigParser<MyCustomSettingsConfig>())
        {
        }
    }
}
