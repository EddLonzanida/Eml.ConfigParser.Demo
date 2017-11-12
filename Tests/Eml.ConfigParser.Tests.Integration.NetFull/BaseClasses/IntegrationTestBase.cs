using Eml.ClassFactory.Contracts;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull.BaseClasses
{
    [Collection(MefFixture.CLASS_FIXTURE)]
    public abstract class IntegrationTestBase
    {
        protected readonly IClassFactory classFactory;

        protected IntegrationTestBase()
        {
            classFactory = Mef.ClassFactory.MefContainer.GetExportedValue<IClassFactory>();
        }
    }
}
