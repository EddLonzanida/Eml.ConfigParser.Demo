using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class IntellisenseCountConfigParser : ConfigParserBase<int, IntellisenseCountConfigParser>
    {
		/// <summary>
		/// DI signature: <![CDATA[IConfigBase<int, IntellisenseCountConfigParser> intellisenseCountConfigParser]]>.
		/// </summary>
		public IntellisenseCountConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
