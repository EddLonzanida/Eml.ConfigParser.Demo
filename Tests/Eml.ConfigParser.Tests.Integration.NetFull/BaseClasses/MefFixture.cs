using System;
using Eml.Mef;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull.BaseClasses
{
    public class MefFixture : IDisposable
    {
        public const string CLASS_FIXTURE = "ClassFactory CollectionDefinition";

        public MefFixture()
        {
            Bootstrapper.Init();
        }

        public void Dispose()
        {
            Mef.ClassFactory.MefContainer?.Dispose();
        }
    }


    [CollectionDefinition(MefFixture.CLASS_FIXTURE)]
    public class ClassFactoryFixtureCollectionDefinition : ICollectionFixture<MefFixture>
    {
        // This class has no code, and is never created. Its purpose is simply
        // to be the place to apply [CollectionDefinition] and all the
        // ICollectionFixture<> interfaces.
    }
}
