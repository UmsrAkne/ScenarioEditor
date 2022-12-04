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
            var scenarioElements = doc.Descendants("scenario");
            Scenarios = new ObservableCollection<Scenario>(
                scenarioElements.Select(scn => new Scenario(scn)));

            RaisePropertyChanged(nameof(Scenarios));
        }
    }
}