using Eml.ClassFactory.Contracts;
using Eml.Extensions;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestBase 
    {
        protected readonly IConfiguration configuration;

        protected readonly IClassFactory classFactory;

        protected IntegrationTestBase()
        {
            configuration = IntegrationTestDiFixture.Configuration;
            classFactory = IntegrationTestDiFixture.ClassFactory;

            classFactory.CheckNotNull("classFactory");
        }
    }
}
