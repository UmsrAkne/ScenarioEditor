using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("image")]
    public class Image
    {
        [XmlAttribute("A")]
        public string A { get; set; }

        [XmlAttribute("B")]
        public string B { get; set; }

        [XmlAttribute("C")]
        public string C { get; set; }

        [XmlAttribute("D")]
        public string D { get; set; }
    }
}