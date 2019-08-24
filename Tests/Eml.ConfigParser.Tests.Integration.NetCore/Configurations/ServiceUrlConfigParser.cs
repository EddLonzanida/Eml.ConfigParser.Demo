using System;
using Microsoft.Extensions.Configuration;
using System.Composition;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class ServiceUrlConfigParser : ConfigParserBase<Uri, ServiceUrlConfigParser>
    {
		/// <summary>
		/// DI signature: <![CDATA[IConfigBase<Uri, ServiceUrlConfigParser> serviceUrlConfigParser]]>.
		/// </summary>
		public ServiceUrlConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
