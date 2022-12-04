using System.Xml.Linq;
using System.Xml.Serialization;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("image")]
    public class Image
    {
        public Image()
        {
        }

        public Image(XElement scenarioElement)
        {
            var imageElement = scenarioElement.Element(ElementName);

            var imageNameA = imageElement?.Attribute(AAttribute);
            A = imageNameA != null ? imageNameA.Value : string.Empty;

            var imageNameB = imageElement?.Attribute(BAttribute);
            B = imageNameB != null ? imageNameB.Value : string.Empty;

            var imageNameC = imageElement?.Attribute(CAttribute);
            C = imageNameC != null ? imageNameC.Value : string.Empty;

            var imageNameD = imageElement?.Attribute(DAttribute);
            D = imageNameD != null ? imageNameD.Value : string.Empty;

            var xAtt = imageElement?.Attribute(XAttribute);
            X = xAtt != null ? double.Parse(xAtt.Value) : 0;

            var yAtt = imageElement?.Attribute(YAttribute);
            Y = yAtt != null ? double.Parse(yAtt.Value) : 0;

            var scale = imageElement?.Attribute(ScaleAttribute);
            Scale = scale != null ? double.Parse(scale.Value) : 1.0;

            var target = imageElement?.Attribute(TargetAttribute);
            Target = target != null ? target.Value : string.Empty;
        }

        public string ElementName => "image";

        [XmlAttribute("A")]
        public string A { get; set; } = string.Empty;

        [XmlAttribute("B")]
        public string B { get; set; } = string.Empty;

        [XmlAttribute("C")]
        public string C { get; set; } = string.Empty;

        [XmlAttribute("D")]
        public string D { get; set; } = string.Empty;

        public double X { get; set; }

        public double Y { get; set; }

        public double Scale { get; set; } = 1.0;

        public string Target { get; set; } = "main";

        private string AAttribute => "a";

        private string BAttribute => "b";

        private string CAttribute => "c";

        private string DAttribute => "d";

        private string ScaleAttribute => "scale";

        private string XAttribute => "x";

        private string YAttribute => "y";

        private string TargetAttribute => "target";
    }
}