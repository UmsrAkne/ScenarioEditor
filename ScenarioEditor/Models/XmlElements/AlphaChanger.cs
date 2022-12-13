namespace ScenarioEditor.Models.XmlElements
{
    public class AlphaChanger : IAnimation
    {
        public string ElementName => "anime";

        public bool IsDefault { get; }

        public string Name { get; set; } = "alphaChanger";

        public double Amount { get; set; } = 0.1;
    }
}