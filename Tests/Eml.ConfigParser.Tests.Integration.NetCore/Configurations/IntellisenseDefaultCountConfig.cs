using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class IntellisenseDefaultCountConfig : ConfigBase<int, IntellisenseDefaultCountConfig>
    {
        public IntellisenseDefaultCountConfig(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
