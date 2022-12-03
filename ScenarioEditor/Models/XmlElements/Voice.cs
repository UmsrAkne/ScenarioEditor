using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("voice")]
    public class Voice
    {
        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("fileName")]
        public string FileName { get; set; }
    }
}