using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class UriListConfig : ConfigBase<List<Uri>, UriListConfig>
    {
        public UriListConfig(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
