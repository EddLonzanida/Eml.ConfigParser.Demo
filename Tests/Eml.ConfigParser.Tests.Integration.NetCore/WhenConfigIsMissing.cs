using Eml.ConfigParser.Exceptions;
using Eml.ConfigParser.Tests.Integration.NetCore.BaseClasses;
using Eml.ConfigParser.Tests.Integration.NetCore.Configurations;
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
                var default2ConnectionString = new Default2ConnectionStringParser(configuration);
            });
        }

        [Fact]
        public void Configuration_ShouldThrowAnError()
        {
            Should.Throw<MissingSettingException>(() =>
            {
                var intellisenseDefaultCountConfig = new IntellisenseDefaultCountConfigParser(configuration);
            });
        }
    }
}
