using System;
using Eml.ConfigParser.Tests.Integration.NetFull.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetFull.Configurations;
using Eml.Mef;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull
{
    public class WhenAConfigIsInDiContainer : IClassFixture<MefFixture>
    {
        [Fact]
        public void Mef_ShouldReturnValue()
        {
            var mef = Mef.ClassFactory.MefContainer;
            var result = new Uri("http://testSite.com/home");

            var sut = mef.GetExportedValue<IConfigBase<Uri, ServiceUrlConfig>>();

            sut.Value.ShouldBe(result);
        }
    }
}
