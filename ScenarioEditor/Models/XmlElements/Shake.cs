using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class Shake : BindableBase, IAnimation
    {
        private int strength;
        private int duration;

        public string ElementName => "anime";

        public bool IsDefault => Strength == 0 && Duration == 0;

        public string Name { get; set; } = "shake";

        public int Strength
        {
            get => strength;
            set
            {
                if (SetProperty(ref strength, value))
                {
                    RaisePropertyChanged(nameof(IsDefault));
                }
            }
        }

        public int Duration
        {
            get => duration;
            set
            {
                if (SetProperty(ref duration, value))
                {
                    RaisePropertyChanged(nameof(IsDefault));
                }
            }
        }

        public override string ToString()
        {
            return $"<anime name=\"{Name}\" " +
                   $"strength=\"{Strength}\" " +
                   $"duration=\"{Duration}\" " +
                   $"/>";
        }
    }
}