using System.Collections.Generic;
using System.Linq;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class BackgroundVoice : BindableBase, IXmlElement
    {
        private string names;
        private int channel;

        public string ElementName => "backgroundVoice";

        public bool IsDefault { get; }

        public string Names { get => names; set => SetProperty(ref names, value); }

        public int Channel { get => channel; set => SetProperty(ref channel, value); }

        public List<string> NameList
        {
            get
            {
                if (Names == null || string.IsNullOrWhiteSpace(Names))
                {
                    return new List<string>();
                }

                return Names.Split(',').Select(n => n.Trim()).ToList();
            }
        }

        public override string ToString()
        {
            return $"<{ElementName} " +
                   $"{nameof(Names).ToLower()}=\"{Names}\" " +
                   $"{nameof(Channel).ToLower()}=\"{Channel}\" " +
                   $"/>";
        }
    }
}