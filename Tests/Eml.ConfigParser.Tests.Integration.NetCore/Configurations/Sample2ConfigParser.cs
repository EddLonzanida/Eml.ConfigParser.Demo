using Eml.ConfigParser;
using Eml.ConfigParser.Parsers;
using Microsoft.Extensions.Configuration;
using System;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class Sample2ConfigParser : ConfigParserBase<Sample2Config, Sample2ConfigParser>
    {
		/// <summary>
		/// DI signature: <![CDATA[IConfigParserBase<Sample2Config, {configParserFn}> sample2ConfigParser]]>.
		/// </summary>
		public Sample2ConfigParser(IConfiguration configuration) 
		: base(configuration, new ComplexTypeConfigParser<Sample2Config>())
        {
        }
    }
}
