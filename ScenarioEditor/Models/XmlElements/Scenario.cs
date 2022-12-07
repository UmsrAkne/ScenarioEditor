using System;
using System.Linq;
using System.Text;
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
            Ignore = scenarioElement.Descendants("ignore").Any();
        }

        public Scenario()
        {
        }

        public string ElementName => "scenario";

        public Voice Voice { get; set; }

        public Text Text { get; set; }

        public Image Image { get; set; }

        public bool Ignore { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"<scenario>");

            if (Ignore)
            {
                sb.Append("<ignore />");
            }

            sb.Append($"{Voice}{Text}");

            if (!Image.IsDefault)
            {
                sb.AppendLine($"{Environment.NewLine}\t{Image}");
            }

            sb.Append("</scenario>");
            return sb.ToString();
        }
    }
}