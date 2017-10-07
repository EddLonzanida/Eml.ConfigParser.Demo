using System.Collections.Generic;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class NumericListConfig : ConfigBase<List<double>, NumericListConfig>
    {
        public NumericListConfig(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
