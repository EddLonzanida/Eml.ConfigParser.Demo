using Eml.ClassFactory.Contracts;
using Eml.ConfigParser.Helpers;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    [Collection(MefFixture.CLASS_FIXTURE)]
    public abstract class IntegrationTestBase 
    {
        protected readonly IConfiguration configuration;
        protected readonly IClassFactory classFactory;

        protected IntegrationTestBase()
        {
            configuration = ConfigBuilder.GetConfiguration();
            classFactory = Mef.ClassFactory.MefContainer.GetExport<IClassFactory>();
        }
    }
}
