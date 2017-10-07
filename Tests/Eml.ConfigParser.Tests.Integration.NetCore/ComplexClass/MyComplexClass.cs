using System.Collections.Generic;

namespace Eml.ConfigParser.Tests.Integration.NetCore.ComplexClass
{
    public class MyComplexClass
    {
        public string StringSetting { get; set; }
        public int IntSetting { get; set; }
        public Dictionary<string, InnerClass> Dictionary { get; set; }
        public List<string> ListOfValues { get; set; }
        public MyEnum AnEnum { get; set; }
    }
}
