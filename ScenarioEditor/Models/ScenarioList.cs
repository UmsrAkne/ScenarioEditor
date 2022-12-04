using System.Collections.ObjectModel;
using System.Linq;
using System.Xml.Linq;
using Prism.Mvvm;
using ScenarioEditor.Models.XmlElements;

namespace ScenarioEditor.Models
{
    public class ScenarioList : BindableBase
    {
        public ObservableCollection<Scenario> Scenarios { get; set; }

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

            RaisePropertyChanged(nameof(Scenarios));
        }
    }
}