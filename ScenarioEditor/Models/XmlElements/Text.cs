using System.Xml.Linq;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("text")]
    public class Text : BindableBase
    {
        private string str;

        public Text()
        {
        }

        public Text(XElement scenarioElement)
        {
            var textElement = scenarioElement.Element(ElementName);

            var s = textElement?.Attribute(StrAttribute);
            if (s != null)
            {
                Str = s.Value;
            }

            var stringAttribute = textElement?.Attribute(StringAttribute);
            if (stringAttribute != null)
            {
                Str = stringAttribute.Value;
            }
        }

        public string Str { get => str; set => SetProperty(ref str, value); }

        public string ElementName { get; set; } = "text";

        private string StrAttribute { get; } = "str";

        private string StringAttribute { get; } = "string";

        public override string ToString()
        {
            return $"<text {StrAttribute}=\"{Str}\" />";
        }
    }
}