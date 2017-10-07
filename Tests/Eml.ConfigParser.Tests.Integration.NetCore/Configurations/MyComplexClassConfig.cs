using Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass;
using Eml.ConfigParser.Tests.Integration.NetCore.CustomParser;
using Microsoft.Extensions.Configuration;
using Eml.ConfigParser;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class MyComplexClassConfig : ConfigBase<MyComplexClass, MyComplexClassConfig>
    {
        public MyComplexClassConfig(IConfiguration configuration)
            : base(configuration, new MyComplexClassConfigParser())
        {
            
        }
    }
}
