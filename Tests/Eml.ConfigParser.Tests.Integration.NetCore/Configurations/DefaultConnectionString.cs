using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class DefaultConnectionString : ConfigBase<string, DefaultConnectionString>
    {
        public DefaultConnectionString(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
