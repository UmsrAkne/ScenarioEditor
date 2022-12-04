using System.Xml.Linq;
using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("scenario")]
    public class Scenario
    {
        public Scenario(XElement scenarioElement)
        {
            Voice = new Voice(scenarioElement);
            Text = new Text(scenarioElement);
            Image = new Image(scenarioElement);
        }

        public Scenario()
        {
        }

        public string ElementName => "scenario";

        public Voice Voice { get; set; }

        public Text Text { get; set; }

        public Image Image { get; set; }
    }
}