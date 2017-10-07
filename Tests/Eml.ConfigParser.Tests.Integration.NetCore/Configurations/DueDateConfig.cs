using System;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class DueDateConfig : ConfigBase<DateTime, DueDateConfig>
    {
        public DueDateConfig(IConfiguration configuration)
            : base(configuration)
        {
        }
    }
}
