using System;
using Eml.ConfigParser.Tests.Integration.NetFull.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetFull.Configurations;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull
{
    public class WhenDiContainer : IntegrationTestBase
    {
        [Fact]
        public void Mef_ShouldReturnValue()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = classFactory.GetExport<ServiceUrlConfigParser>();

            sut.Value.ShouldBe(result);
        }

        [Fact]
        public void Mef_ShouldReturnValueWhenGenerics()
        {
            var result = new Uri("http://testSite.com/home");

            var sut = classFactory.GetExport<IConfigParserBase<Uri, ServiceUrlConfigParser>>();

            sut.Value.ShouldBe(result);
        }
    }
}
