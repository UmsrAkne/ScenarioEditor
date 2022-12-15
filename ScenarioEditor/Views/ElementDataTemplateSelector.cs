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
                templateKey =
                    element.ElementName == new AlphaChanger().ElementName ? $"{nameof(AlphaChanger)}AnimationDataTemplate" :
                    element.ElementName == new Shake().ElementName ? $"{nameof(Shake)}AnimationDataTemplate" :
                    element.ElementName == new Slide().ElementName ? $"{nameof(Slide)}AnimationDataTemplate" :
                    element.ElementName == new Flash().ElementName ? $"{nameof(Flash)}AnimationDataTemplate" :
                    element.ElementName == new Bound().ElementName ? $"{nameof(Bound)}AnimationDataTemplate" :
                    string.Empty;
            }

            return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate;
        }
    }
}