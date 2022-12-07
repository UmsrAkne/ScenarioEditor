using System.Xml.Linq;
using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("voice")]
    public class Voice
    {
        public Voice()
        {
        }

        /// <summary>
        /// Scenario 要素を含む XElement から Voice を生成します。
        /// </summary>
        /// <param name="scenarioElement">
        /// 一つの Voice 要素を含む Scenario のみに対応。２つ以上を含む場合、２つ目以降のVoice は認識しません</param>
        public Voice(XElement scenarioElement)
        {
            var voiceElement = scenarioElement.Element(ElementName);

            var numberAttribute = voiceElement?.Attribute(NumberAttribute);
            if (numberAttribute != null)
            {
                Number = int.Parse(numberAttribute.Value);
            }

            var fileNameAttribute = voiceElement?.Attribute(FileNameAttribute);
            if (fileNameAttribute != null)
            {
                FileName = fileNameAttribute.Value;
            }
        }

        [XmlAttribute("number")]
        public int Number { get; set; }

        [XmlAttribute("fileName")]
        public string FileName { get; set; } = string.Empty;

        public string ElementName { get; } = "voice";

        public bool IsDefault => FileName == string.Empty && Number == 0;

        public string Name
        {
            get
            {
                if (FileName != string.Empty)
                {
                    return FileName;
                }

                return Number != 0 ? Number.ToString() : string.Empty;
            }
        }

        private string NumberAttribute { get; } = "number";

        private string FileNameAttribute { get; } = "fileName";

        public override string ToString()
        {
            if (FileName != string.Empty)
            {
                return $"<{ElementName} {FileNameAttribute}=\"{FileName}\" />";
            }

            if (Number != 0)
            {
                return $"<{ElementName} {NumberAttribute}=\"{Number}\" />";
            }

            return $"<{ElementName} {NumberAttribute}=\"0\" />";
        }
    }
}