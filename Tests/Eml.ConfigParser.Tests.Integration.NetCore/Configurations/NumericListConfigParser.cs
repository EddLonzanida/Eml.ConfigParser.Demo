using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Composition;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class NumericListConfigParser : ConfigParserBase<List<double>, NumericListConfigParser>
    {
		/// <summary>
		/// DI signature: <![CDATA[IConfigBase<List<double>, NumericListConfigParser> numericListConfigParser]]>.
		/// </summary>
		public NumericListConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
