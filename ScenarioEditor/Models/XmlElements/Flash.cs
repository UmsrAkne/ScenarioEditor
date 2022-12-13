namespace ScenarioEditor.Models.XmlElements
{
    public class Flash : IAnimation
    {
        public string ElementName => "anime";

        public bool IsDefault { get; }

        public string Name { get; set; } = "flash";

        public int Cycle { get; set; }

        public int Duration { get; set; }

        public int RepeatCount { get; set; }

        public double Alpha { get; set; } = 1.0;
    }
}