using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows;
using System.Xml.Linq;
using Prism.Commands;
using Prism.Mvvm;
using ScenarioEditor.Models.XmlElements;

namespace ScenarioEditor.Models
{
    public class ScenarioList : BindableBase
    {
        private Scenario selectedItem;

        public ObservableCollection<Scenario> Scenarios { get; set; }

        public Scenario SelectedItem { get => selectedItem; set => SetProperty(ref selectedItem, value); }

        public ContentsLoader ContentsLoader { get; set; }

        public DelegateCommand ExportXmlCommand => new DelegateCommand(() =>
        {
            var sb = new StringBuilder();
            sb.AppendLine("<root>");

            foreach (var scn in Scenarios)
            {
                sb.AppendLine(scn.ToString());
            }

            sb.AppendLine("</root>");
            Clipboard.SetDataObject(sb.ToString());
        });

        public void Load(XDocument doc)
        {
            const string scenarioElementName = "scenario";
            var scenarioElements = doc.Descendants(scenarioElementName).ToList();

            const string scenarioElementAlias = "scn";
            var scnElements = doc.Descendants(scenarioElementAlias).ToList();

            if (scenarioElements.Count() != 0)
            {
                Scenarios = new ObservableCollection<Scenario>(
                    scenarioElements.Select(scn => new Scenario(scn)));
            }

            if (scnElements.Count() != 0)
            {
                Scenarios = new ObservableCollection<Scenario>(
                    scnElements.Select(scn => new Scenario(scn)));
            }

            if (ContentsLoader != null)
            {
                foreach (var s in Scenarios)
                {
                    s.UpdateUrls(ContentsLoader);
                    s.SetImageFileInfos(ContentsLoader);
                }
            }

            RaisePropertyChanged(nameof(Scenarios));
        }
    }
}