using Eml.ClassFactory.Contracts;
using Eml.Extensions;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull.BaseClasses
{
    [Collection(IntegrationTestDiFixture.COLLECTION_DEFINITION)]
    public abstract class IntegrationTestBase
    {
        protected readonly IClassFactory classFactory;

        protected IntegrationTestBase()
        {
            classFactory = IntegrationTestDiFixture.ClassFactory;

            classFactory.CheckNotNull("classFactory");
        }
    }
}
