using Prism.Mvvm;
using ScenarioEditor.Models;

namespace ScenarioEditor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        public MainWindowViewModel()
        {
        }

        public string Title { get => title; set => SetProperty(ref title, value); }

        public void LoadDirectory(string directoryPath)
        {
            var loader = new ContentsLoader(directoryPath);
            loader.LoadScenario();
            loader.LoadSetting();
            loader.LoadImageFileList();
            loader.LoadVoiceFileList();
        }
    }
}