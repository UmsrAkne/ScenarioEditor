using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("scenario")]
    public class Scenario
    {
        [XmlElement("voice")]
        public string Voice { get; set; }

        [XmlElement("text")]
        public string Text { get; set; }

        [XmlElement("image")]
        public string Image { get; set; }
    }
}