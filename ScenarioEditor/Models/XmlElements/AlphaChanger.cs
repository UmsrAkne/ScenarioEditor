using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class AlphaChanger : BindableBase, IAnimation
    {
        private double amount = 0.1;

        public string ElementName => "anime";

        public bool IsDefault => false;

        public string Name { get; set; } = "alphaChanger";

        public double Amount { get => amount; set => SetProperty(ref amount, value); }

        public override string ToString()
        {
            return $"<anime name=\"{Name}\" " +
                   $"amount=\"{Amount}\" " +
                   $"/>";
        }
    }
}