using System.Xml.Linq;
using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("text")]
    public class Text
    {
        public Text()
        {
        }

        public Text(XElement scenarioElement)
        {
            var textElement = scenarioElement.Element(ElementName);

            var str = textElement?.Attribute(StrAttribute);
            if (str != null)
            {
                Str = str.Value;
            }

            var stringAttribute = textElement?.Attribute(StringAttribute);
            if (stringAttribute != null)
            {
                Str = stringAttribute.Value;
            }
        }

        [XmlAttribute("str")]
        public string Str { get; set; }

        public string ElementName { get; set; } = "text";

        private string StrAttribute { get; } = "str";

        private string StringAttribute { get; } = "string";
    }
}