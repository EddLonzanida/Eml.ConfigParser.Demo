using System;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class ExpiryConfig : ConfigBase<TimeSpan, ExpiryConfig>
    {
        public ExpiryConfig(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
