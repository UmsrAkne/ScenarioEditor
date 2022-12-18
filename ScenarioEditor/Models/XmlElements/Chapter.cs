using System.Xml.Linq;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class Chapter : BindableBase, IXmlElement
    {
        private string name = string.Empty;

        public Chapter()
        {
        }

        public Chapter(XElement scenarioElement)
        {
            var chapterElement = scenarioElement.Element(ElementName);
            if (chapterElement == null)
            {
                return;
            }

            var chapterName = chapterElement.Attribute(nameof(Name).ToLower());
            Name = chapterName != null ? chapterName.Value : string.Empty;
        }

        public string ElementName => "chapter";

        public string Name { get => name; set => SetProperty(ref name, value); }

        public bool IsDefault => Name == string.Empty;

        public override string ToString()
        {
            return !IsDefault ? $"<{ElementName} {nameof(Name).ToLower()}=\"{Name}\" />" : string.Empty;
        }
    }
}