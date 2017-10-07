using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class IntellisenseCountConfig : ConfigBase<int, IntellisenseCountConfig>
    {
        public IntellisenseCountConfig(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
