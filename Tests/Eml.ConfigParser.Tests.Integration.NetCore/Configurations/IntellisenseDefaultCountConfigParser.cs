using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class IntellisenseDefaultCountConfigParser : ConfigParserBase<int, IntellisenseDefaultCountConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<int, IntellisenseDefaultCountConfigParser> intellisenseDefaultCountConfigParser]]>.
        /// </summary>
		public IntellisenseDefaultCountConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
