namespace ScenarioEditor.Models.XmlElements
{
    public class Slide : IAnimation
    {
        public string ElementName => "anime";

        public bool IsDefault { get; }

        public string Name { get; set; } = "slide";

        public double Speed { get; set; }

        public double Degree { get; set; }

        public int RepeatCount { get; set; }

        public int Distance { get; set; }

        public override string ToString()
        {
            return $"<{Name} " +
                   $"speed=\"{Speed}\" " +
                   $"degree=\"{Degree}\" " +
                   $"distance=\"{Distance}\" " +
                   $"repeatCount=\"{RepeatCount}\" " +
                   $"/>";
        }
    }
}