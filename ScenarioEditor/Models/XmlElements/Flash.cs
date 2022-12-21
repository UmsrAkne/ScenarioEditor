using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class Flash : BindableBase, IAnimation
    {
        private int cycle;
        private int duration;
        private int repeatCount;

        public string ElementName => "anime";

        public bool IsDefault { get; }

        public string Name { get; set; } = "flash";

        public int Cycle { get => cycle; set => SetProperty(ref cycle, value); }

        public int Duration { get => duration; set => SetProperty(ref duration, value); }

        public int RepeatCount { get => repeatCount; set => SetProperty(ref repeatCount, value); }

        public double Alpha { get; set; } = 1.0;

        public override string ToString()
        {
            return $"<anime name=\"{Name}\" " +
                   $"cycle=\"{Cycle}\" " +
                   $"duration=\"{Duration}\" " +
                   $"repeatCount=\"{RepeatCount}\" " +
                   $"/>";
        }
    }
}