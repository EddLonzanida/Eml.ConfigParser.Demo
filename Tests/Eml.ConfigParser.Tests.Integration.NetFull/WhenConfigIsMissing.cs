using Eml.ConfigParser.Exceptions;
using Eml.ConfigParser.Tests.Integration.NetFull.Configurations;
using Shouldly;
using Xunit;

namespace Eml.ConfigParser.Tests.Integration.NetFull
{
    public class WhenConfigIsMissing
    {
        [Fact]
        public void ConnectionString_ShouldThrowAnError()
        {
            Should.Throw<MissingSettingException>(() =>
            {
                var default2ConnectionString = new Default2ConnectionString();
            });
        }

        [Fact]
        public void Configuration_ShouldThrowAnError()
        {
            Should.Throw<MissingSettingException>(() =>
            {
                var intellisenseDefaultCountConfig = new IntellisenseDefaultCountConfigParser();
            });
        }
    }
}
