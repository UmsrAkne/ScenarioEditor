using System.Xml.Linq;

namespace ScenarioEditor.Models.XmlElements
{
    public class Se
    {
        public Se()
        {
        }

        public Se(XElement scenarioElement)
        {
            var seElement = scenarioElement.Element(ElementName);

            var numberAttribute = seElement?.Attribute(NumberAttribute);
            if (numberAttribute != null)
            {
                Number = int.Parse(numberAttribute.Value);
            }

            var fileNameAttribute = seElement?.Attribute(FileNameAttribute);
            if (fileNameAttribute != null)
            {
                FileName = fileNameAttribute.Value;
            }

            var repeatCountAtt = seElement?.Attribute(RepeatCountAttribute);
            if (repeatCountAtt != null)
            {
                RepeatCount = int.Parse(repeatCountAtt.Value);
            }
        }

        public int RepeatCount { get; set; }

        public string FileName { get; set; } = string.Empty;

        public int Number { get; set; }

        public string ElementName => "se";

        public string NumberAttribute => "number";

        public string FileNameAttribute => "fileName";

        public string RepeatCountAttribute => "repeatCount";

        public bool IsDefault => FileName == string.Empty && Number == 0;
    }
}