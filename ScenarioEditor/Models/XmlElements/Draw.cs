using System.Xml.Linq;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("image")]
    public class Draw : BindableBase, IXmlElement
    {
        private string a = string.Empty;
        private string b = string.Empty;
        private string c = string.Empty;
        private string d = string.Empty;
        private string target = "main";

        public Draw()
        {
        }

        public Draw(XElement scenarioElement)
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

            var tg = imageElement?.Attribute(TargetAttribute);
            Target = tg != null ? tg.Value : string.Empty;
        }

        public string ElementName => "draw";

        public string A { get => a; set => SetProperty(ref a, value); }

        public string B { get => b; set => SetProperty(ref b, value); }

        public string C { get => c; set => SetProperty(ref c, value); }

        public string D { get => d; set => SetProperty(ref d, value); }

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

            return $"<draw " +
                   $"{AAttribute}=\"{A}\" " +
                   $"{BAttribute}=\"{B}\" " +
                   $"{CAttribute}=\"{C}\" " +
                   $"{DAttribute}=\"{D}\" " +
                   $"{TargetAttribute}=\"{Target}\" " + $"/>";
        }
    }
}