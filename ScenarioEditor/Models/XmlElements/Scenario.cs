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
    public class Scenario : BindableBase, IXmlElement
    {
        private ObservableCollection<Image> images = new ObservableCollection<Image>();
        private ObservableCollection<Draw> draws = new ObservableCollection<Draw>();
        private ObservableCollection<IAnimation> animations = new ObservableCollection<IAnimation>();
        private Se se;
        private BackgroundVoice backgroundVoice;
        private bool ignore;

        public Scenario(XElement scenarioElement)
        {
            Voice = new Voice(scenarioElement);
            Text = new Text(scenarioElement);
            Se = new Se(scenarioElement);
            Images.Add(new Image(scenarioElement));
            Draws.Add(new Draw(scenarioElement));
            Animations = new ObservableCollection<IAnimation>(
                    AnimationGenerator.GetAnimation(scenarioElement));

            Ignore = scenarioElement.Descendants("ignore").Any();
            Chapter = new Chapter(scenarioElement);
        }

        public Scenario()
        {
        }

        public string ElementName => "scenario";

        public bool IsDefault { get; }

        public Voice Voice { get; set; }

        public Text Text { get; set; }

        public Se Se { get => se; set => SetProperty(ref se, value); }

        public BackgroundVoice BackgroundVoice { get => backgroundVoice; set => SetProperty(ref backgroundVoice, value); }

        public ObservableCollection<Image> Images { get => images; set => SetProperty(ref images, value); }

        public ObservableCollection<Draw> Draws { get => draws; set => SetProperty(ref draws, value); }

        public ObservableCollection<IAnimation> Animations { get => animations; set => SetProperty(ref animations, value); }

        public List<string> Urls { get; set; }

        public bool Ignore { get => ignore; set => SetProperty(ref ignore, value); }

        public Chapter Chapter { get; set; }

        private ContentsLoader ContentsLoader { get; set; }

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
            RaisePropertyChanged(nameof(Urls));
        }

        /// <summary>
        /// シナリオ内の全てのImage, Drawに対して画像ファイルの情報をセットします
        /// </summary>
        /// <param name="loader">画像ファイルの情報をロードしたローダーを入力します</param>
        public void SetImageFileInfos(ContentsLoader loader)
        {
            foreach (var image in Images)
            {
                image.ImageFiles = loader.ImageFileInfos;
                image.ImageChanged += (sender, args) => UpdateUrls(loader);
            }
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
                sb.AppendLine($"\t{Se}");
            }

            if (BackgroundVoice != null && !BackgroundVoice.IsDefault)
            {
                sb.AppendLine($"\t{BackgroundVoice}");
            }

            foreach (var a in Animations)
            {
                sb.AppendLine($"\t{a.ToString()}");
            }

            if (Chapter != null && !Chapter.IsDefault)
            {
                sb.AppendLine($"\t{Chapter}");
            }

            sb.Append("</scenario>");
            return sb.ToString();
        }
    }
}