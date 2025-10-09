using System.Xml.Serialization;

namespace Cucumber.Cannery.Domain.Documentation
{
    public class XmlParam
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlText]
        public string Description { get; set; }
    }
}