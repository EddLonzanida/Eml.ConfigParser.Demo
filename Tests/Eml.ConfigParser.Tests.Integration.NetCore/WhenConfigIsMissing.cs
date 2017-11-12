using Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
using Eml.ConfigParser.Exceptions;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetCore
{
    public class WhenConfigIsMissing : IntegrationTestBase
    {
        [Fact]
        public void ConnectionString_ShouldThrowAnError()
        {
            Should.Throw<MissingSettingException>(() =>
            {
                var default2ConnectionString = new Default2ConnectionString(configuration);
            });
        }

        [Fact]
        public void Configuration_ShouldThrowAnError()
        {
            Should.Throw<MissingSettingException>(() =>
            {
                var intellisenseDefaultCountConfig = new IntellisenseDefaultCountConfig(configuration);
            });
        }
    }
}
