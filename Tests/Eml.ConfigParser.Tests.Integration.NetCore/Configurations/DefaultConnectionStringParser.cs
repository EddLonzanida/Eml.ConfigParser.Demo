using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class DefaultConnectionStringParser : ConfigParserBase<string, DefaultConnectionStringParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<string, DefaultConnectionStringParser> defaultConnectionStringParser]]>.
        /// </summary>
        public DefaultConnectionStringParser(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
