using Prism.Mvvm;

namespace ScenarioEditor.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string title = "Prism Application";

        public MainWindowViewModel()
        {
        }

        public string Title { get => title; set => SetProperty(ref title, value); }
    }
}
