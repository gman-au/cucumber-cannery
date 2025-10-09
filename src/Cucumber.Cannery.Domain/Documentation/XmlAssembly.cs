using System.Xml.Serialization;

namespace Cucumber.Cannery.Domain.Documentation
{
    public class XmlAssembly
    {
        [XmlElement("name")]
        public string Name { get; set; }
    }
}