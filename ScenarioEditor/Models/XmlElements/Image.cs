using System.Xml.Linq;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("image")]
    public class Image : BindableBase
    {
        private string a = string.Empty;
        private string b = string.Empty;
        private string c = string.Empty;
        private string d = string.Empty;
        private double x;
        private double y;
        private double scale = 1.0;
        private string target = "main";

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

            var sc = imageElement?.Attribute(ScaleAttribute);
            Scale = sc != null ? double.Parse(sc.Value) : 1.0;

            var tg = imageElement?.Attribute(TargetAttribute);
            Target = tg != null ? tg.Value : string.Empty;
        }

        public string ElementName => "image";

        public string A { get => a; set => SetProperty(ref a, value); }

        public string B { get => b; set => SetProperty(ref b, value); }

        public string C { get => c; set => SetProperty(ref c, value); }

        public string D { get => d; set => SetProperty(ref d, value); }

        public double X { get => x; set => SetProperty(ref x, value); }

        public double Y { get => y; set => SetProperty(ref y, value); }

        public double Scale { get => scale; set => SetProperty(ref scale, value); }

        public string Target { get => target; set => SetProperty(ref target, value); }

        public bool IsDefault => A + B + C + D == string.Empty;

        private string AAttribute => "a";

        private string BAttribute => "b";

        private string CAttribute => "c";

        private string DAttribute => "d";

        private string ScaleAttribute => "scale";

        private string XAttribute => "x";

        private string YAttribute => "y";

        private string TargetAttribute => "target";

        public override string ToString()
        {
            if (IsDefault)
            {
                return string.Empty;
            }

            return $"<image " +
                   $"{AAttribute}=\"{A}\" " +
                   $"{BAttribute}=\"{B}\" " +
                   $"{CAttribute}=\"{C}\" " +
                   $"{DAttribute}=\"{D}\" " +
                   $"{ScaleAttribute}=\"{Scale}\" " +
                   $"{XAttribute}=\"{X}\" " +
                   $"{YAttribute}=\"{Y}\" " +
                   $"{TargetAttribute}=\"{Target}\" " + $"/>";
        }
    }
}