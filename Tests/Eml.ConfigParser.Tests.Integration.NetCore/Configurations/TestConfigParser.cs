using Eml.ConfigParser;
using Eml.ConfigParser.Parsers;
using Microsoft.Extensions.Configuration;
using System;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class TestConfigParser : ConfigParserBase<string, TestConfigParser>
    {
		/// <summary>
		/// DI signature: <![CDATA[IConfigParserBase<string, {configParserFn}> testConfigParser]]>.
		/// </summary>
		public TestConfigParser(IConfiguration configuration) 
		: base(configuration)
        {
        }
    }
}
