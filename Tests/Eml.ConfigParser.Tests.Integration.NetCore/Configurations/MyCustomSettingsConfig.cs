using Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass;
using System.Collections.Generic;

namespace Eml.ConfigParser.Tests.Integration.NetCore.Configurations
{
    // Properties here should match the config file entries.
    public class MyCustomSettingsConfig
    {
        public string StringSetting { get; set; }
        public int IntSetting { get; set; }
        public Dictionary<string, InnerClass> Dictionary { get; set; }
        public List<string> ListOfValues { get; set; }
        public MyEnum AnEnum { get; set; }
    }
}
