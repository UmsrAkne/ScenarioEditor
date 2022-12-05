using System;
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

        private string NumberAttribute { get; } = "number";

        private string FileNameAttribute { get; } = "fileName";
    }
}