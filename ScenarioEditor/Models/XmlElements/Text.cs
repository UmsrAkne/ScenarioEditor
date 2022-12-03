using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("text")]
    public class Text
    {
        [XmlAttribute("str")]
        public string Str { get; set; }
    }
}