using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cucumber.Cannery.Domain.Documentation
{
    public class XmlMember {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlElement("summary")]
        public string Summary { get; set; }

        [XmlElement("param")]
        public List<XmlParam> Params { get; set; }
    }
}