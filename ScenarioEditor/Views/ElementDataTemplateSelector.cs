using System.Windows;
using System.Windows.Controls;
using ScenarioEditor.Models.XmlElements;

namespace ScenarioEditor.Views
{
    public class ElementDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = (IXmlElement)item;
            var templateKey = string.Empty;

            if (element != null)
            {
                templateKey = element.ElementName == new Se().ElementName ? "SeElementDataTemplate" : string.Empty;
            }

            return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate;
        }
    }
}