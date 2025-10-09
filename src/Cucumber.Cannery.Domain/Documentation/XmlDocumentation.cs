using System.Collections.Generic;
using System.Xml.Serialization;

namespace Cucumber.Cannery.Domain.Documentation
{
    [XmlRoot("doc")]
    public class XmlDocumentation {

        [XmlElement("assembly")]
        public XmlAssembly Assembly { get; set; }

        [XmlArray("members")]
        [XmlArrayItem("member")]
        public List<XmlMember> Members { get; set; }
    }
}