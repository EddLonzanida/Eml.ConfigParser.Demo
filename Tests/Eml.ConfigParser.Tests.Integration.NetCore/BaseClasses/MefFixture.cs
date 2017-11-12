using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using Eml.Mef;
using Eml.ConfigParser.Helpers;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    public class MefFixture : IDisposable
    {
        public const string CLASS_FIXTURE = "ClassFactory CollectionDefinition";
        public MefFixture()
        {
            var configuration = ConfigBuilder.GetConfiguration();
            var instanceRegistrations = new List<Func<ContainerConfiguration, ExportDescriptorProvider>>
            {
                r => r.WithInstance(configuration)      //register IConfiguration instance
            };
            Bootstrapper.Init(instanceRegistrations);
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
