using Microsoft.Extensions.Configuration;
using System;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class ExpiryConfigParser : ConfigParserBase<TimeSpan, ExpiryConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<TimeSpan, ExpiryConfigParser> expiryConfigParser]]>.
        /// </summary>
        public ExpiryConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
