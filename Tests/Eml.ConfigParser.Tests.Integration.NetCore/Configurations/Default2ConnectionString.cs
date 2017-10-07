using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class Default2ConnectionString : ConfigBase<string, Default2ConnectionString>
    {
        public Default2ConnectionString(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
