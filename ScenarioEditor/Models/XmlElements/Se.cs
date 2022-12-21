using System.Xml.Linq;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class Se : BindableBase, IXmlElement
    {
        private string fileName = string.Empty;
        private int number;
        private int repeatCount;

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

        public int RepeatCount { get => repeatCount; set => SetProperty(ref repeatCount, value); }

        public string FileName { get => fileName; set => SetProperty(ref fileName, value); }

        public int Number { get => number; set => SetProperty(ref number, value); }

        public string ElementName => "se";

        public string NumberAttribute => "number";

        public string FileNameAttribute => "fileName";

        public string RepeatCountAttribute => "repeatCount";

        public bool IsDefault => FileName == string.Empty && Number == 0;

        public override string ToString()
        {
            if (FileName != string.Empty)
            {
                return $"<{ElementName} {FileNameAttribute}=\"{FileName}\" {RepeatCountAttribute}=\"{RepeatCount}\" />";
            }

            if (Number != 0)
            {
                return $"<{ElementName} {NumberAttribute}=\"{Number}\" {RepeatCountAttribute}=\"{RepeatCount}\" />";
            }

            return $"<{ElementName} {NumberAttribute}=\"0\" />";
        }
    }
}