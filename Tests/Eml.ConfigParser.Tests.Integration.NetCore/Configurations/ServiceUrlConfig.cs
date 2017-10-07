using System;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class ServiceUrlConfig :  ConfigBase<Uri, ServiceUrlConfig>
    {
        public ServiceUrlConfig(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
