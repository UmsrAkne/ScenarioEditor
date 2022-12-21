namespace ScenarioEditor.Models.XmlElements
{
    public interface IXmlElement
    {
        string ElementName { get; }

        bool IsDefault { get; }

        string ToString();
    }
}