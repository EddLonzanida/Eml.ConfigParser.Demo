using System;
using Eml.Mef;

namespace Eml.ConfigParser.Tests.Integration.NetFull.BaseClasses
{
    public class MefFixture : IDisposable
    {
        public MefFixture()
        {
            Bootstrapper.Init();
        }

        public void Dispose()
        {
            Mef.ClassFactory.MefContainer?.Dispose();
        }
    }
}
