using System.Windows;
using System.Windows.Controls;
using ScenarioEditor.Models.XmlElements;

namespace ScenarioEditor.Views
{
    public class ElementDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = (IAnimation)item;
            var templateKey = string.Empty;

            if (element != null)
            {
                templateKey =
                    element.Name == new AlphaChanger().Name ? $"{nameof(AlphaChanger)}AnimationDataTemplate" :
                    element.Name == new Shake().Name ? $"{nameof(Shake)}AnimationDataTemplate" :
                    element.Name == new Slide().Name ? $"{nameof(Slide)}AnimationDataTemplate" :
                    element.Name == new Flash().Name ? $"{nameof(Flash)}AnimationDataTemplate" :
                    element.Name == new Bound().Name ? $"{nameof(Bound)}AnimationDataTemplate" :
                    string.Empty;
            }

            return ((FrameworkElement)container).FindResource(templateKey) as DataTemplate;
        }
    }
}