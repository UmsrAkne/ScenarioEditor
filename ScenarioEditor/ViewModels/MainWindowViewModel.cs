using Prism.Mvvm;
using ScenarioEditor.Models;

namespace ScenarioEditor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";
        private ScenarioList scenarioList;

        public MainWindowViewModel()
        {
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public ScenarioList ScenarioList { get => scenarioList; set => SetProperty(ref scenarioList, value); }

        public void LoadDirectory(string directoryPath)
        {
            var loader = new ContentsLoader(directoryPath);
            loader.LoadScenario();
            loader.LoadSetting();
            loader.LoadImageFileList();
            loader.LoadVoiceFileList();

            ScenarioList = new ScenarioList();
            ScenarioList.Load(loader.ScenarioXml);
        }
    }
}