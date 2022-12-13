namespace ScenarioEditor.Models.XmlElements
{
    public class Bound : IAnimation
    {
        public string ElementName => "anime";

        public bool IsDefault { get; }

        public string Name { get; set; } = "bound";

        public int Duration { get; set; }

        public int Degree { get; set; }

        public int Strength { get; set; }

        public int RepeatCount { get; set; }
    }
}