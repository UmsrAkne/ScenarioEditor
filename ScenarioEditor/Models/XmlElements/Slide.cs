using Prism.Mvvm;

namespace ScenarioEditor.Models.XmlElements
{
    public class Slide : BindableBase, IAnimation
    {
        private double speed;
        private double degree;
        private int repeatCount;
        private int distance;

        public string ElementName => "anime";

        public bool IsDefault => false;

        public string Name { get; set; } = "slide";

        public double Speed { get => speed; set => SetProperty(ref speed, value); }

        public double Degree { get => degree; set => SetProperty(ref degree, value); }

        public int Distance { get => distance; set => SetProperty(ref distance, value); }

        public int RepeatCount { get => repeatCount; set => SetProperty(ref repeatCount, value); }

        public override string ToString()
        {
            return $"<anime name=\"{Name}\" " +
                   $"speed=\"{Speed}\" " +
                   $"degree=\"{Degree}\" " +
                   $"distance=\"{Distance}\" " +
                   $"repeatCount=\"{RepeatCount}\" " +
                   $"/>";
        }
    }
}