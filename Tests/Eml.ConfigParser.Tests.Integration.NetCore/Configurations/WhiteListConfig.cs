using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class WhiteListConfig : ConfigBase<List<string>, WhiteListConfig>
    {
        public WhiteListConfig(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
