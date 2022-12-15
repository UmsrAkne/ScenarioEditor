using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class Bound : BindableBase, IAnimation
    {
        private int duration;
        private int degree;
        private int strength;
        private int repeatCount;

        public string ElementName => "anime";

        public bool IsDefault { get; }

        public string Name { get; set; } = "bound";

        public int Duration { get => duration; set => SetProperty(ref duration, value); }

        public int Degree { get => degree; set => SetProperty(ref degree, value); }

        public int Strength { get => strength; set => SetProperty(ref strength, value); }

        public int RepeatCount { get => repeatCount; set => SetProperty(ref repeatCount, value); }

        public override string ToString()
        {
            return $"<{Name} " +
                   $"strength=\"{Strength}\" " +
                   $"degree=\"{Degree}\" " +
                   $"duration=\"{Duration}\" " +
                   $"repeatCount=\"{RepeatCount}\" " +
                   $"/>";
        }
    }
}