using System.Composition;
using Eml.ConfigParser.Parsers;
using Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass;
using Microsoft.Extensions.Configuration;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    public class MyComplexClassConfigParser : ConfigParserBase<MyComplexClass, MyComplexClassConfigParser>
    {
        /// <summary>
        /// DI signature: <![CDATA[IConfigBase<MyComplexClass, MyComplexClassConfigParser> myComplexClassConfigParser]]>.
        /// </summary>
        public MyComplexClassConfigParser(IConfiguration configuration)
            : base(configuration, new ComplexTypeConfigParser<MyComplexClass>())
        {
        }
    }
}
