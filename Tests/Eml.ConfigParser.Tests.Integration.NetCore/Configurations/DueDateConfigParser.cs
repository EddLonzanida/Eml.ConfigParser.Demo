using Microsoft.Extensions.Configuration;
using System;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class DueDateConfigParser : ConfigParserBase<DateTime, DueDateConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<DateTime, DueDateConfigParser> dueDateConfigParser]]>.
        /// </summary>
        public DueDateConfigParser(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
