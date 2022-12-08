using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml.Serialization;
using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    [XmlRoot("scenario")]
    public class Scenario : BindableBase
    {
        private ObservableCollection<Image> images = new ObservableCollection<Image>();
        private ObservableCollection<Draw> draws = new ObservableCollection<Draw>();
        private Se se;

        public Scenario(XElement scenarioElement)
        {
            Voice = new Voice(scenarioElement);
            Text = new Text(scenarioElement);
            Se = new Se(scenarioElement);
            Images.Add(new Image(scenarioElement));
            Draws.Add(new Draw(scenarioElement));
            Ignore = scenarioElement.Descendants("ignore").Any();
        }

        public Scenario()
        {
        }

        public string ElementName => "scenario";

        public Voice Voice { get; set; }

        public Text Text { get; set; }

        public Se Se { get => se; set => SetProperty(ref se, value); }

        public ObservableCollection<Image> Images { get => images; set => SetProperty(ref images, value); }

        public ObservableCollection<Draw> Draws { get => draws; set => SetProperty(ref draws, value); }

        public List<string> Urls { get; set; }

        public bool Ignore { get; set; }

        public void UpdateUrls(ContentsLoader loader)
        {
            var img = Images.First();
            Urls = new List<string> { img.A, img.B, img.C, img.D }.Where(s => s != string.Empty).ToList();
            var list = new List<string>();

            foreach (var url in Urls)
            {
                var file = loader.ImageFileInfos.FirstOrDefault(f => Path.GetFileNameWithoutExtension(f.Name) == url);
                if (file != null)
                {
                    list.Add(file.FullName);
                }
            }

            Urls = list;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"<scenario>");

            if (Ignore)
            {
                sb.Append("<ignore />");
            }

            sb.Append($"{Voice}{Text}");

            if (Images.Any(i => !i.IsDefault))
            {
                foreach (var i in Images)
                {
                    sb.AppendLine($"{Environment.NewLine}\t{i}");
                }
            }

            if (Draws.Any(d => !d.IsDefault))
            {
                foreach (var d in Images)
                {
                    sb.AppendLine($"{Environment.NewLine}\t{d}");
                }
            }

            if (Se != null && !Se.IsDefault)
            {
                sb.AppendLine($"{Environment.NewLine}\t{Se}");
            }

            sb.Append("</scenario>");
            return sb.ToString();
        }
    }
}