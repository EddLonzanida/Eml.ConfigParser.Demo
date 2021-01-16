using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class Default2ConnectionStringParser : ConfigParserBase<string, Default2ConnectionStringParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<string, Default2ConnectionString> default2ConnectionString]]>.
        /// </summary>
        public Default2ConnectionStringParser(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
