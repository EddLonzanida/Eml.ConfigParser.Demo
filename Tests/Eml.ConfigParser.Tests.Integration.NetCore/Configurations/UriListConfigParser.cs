using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class UriListConfigParser : ConfigParserBase<List<Uri>, UriListConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<List<Uri>, UriListConfigParser> uriListConfigParser]]>.
        /// </summary>
        public UriListConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
