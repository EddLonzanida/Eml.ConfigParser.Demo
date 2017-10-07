using System;
using System.Collections.Generic;
using System.Composition.Hosting;
using System.Composition.Hosting.Core;
using Eml.Mef;

namespace Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses
{
    public class MefFixture : IDisposable
    {
        public MefFixture()
        {
            var configuration = IntegrationTestBase.GetConfiguration();
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
}
