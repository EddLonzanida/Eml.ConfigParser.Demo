using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class WhiteListConfigParser : ConfigParserBase<List<string>, WhiteListConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<List<string>, WhiteListConfigParser> whiteListConfigParser]]>.
        /// </summary>
		public WhiteListConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
