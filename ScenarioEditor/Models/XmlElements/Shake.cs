namespace ScenarioEditor.Models.XmlElements
{
    public class Shake : IAnimation
    {
        public string ElementName => "anime";

        public bool IsDefault => Strength == 0 && Duration == 0;

        public string Name { get; set; } = "shake";

        public int Strength { get; set; }

        public int Duration { get; set; }
    }
}