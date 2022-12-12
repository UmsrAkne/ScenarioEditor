using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace ScenarioEditor.Models.XmlElements
{
    public static class AnimationGenerator
    {
        public static List<IAnimation> GetAnimation(XElement scenarioElement)
        {
            var animeElements = scenarioElement.Elements("anime").ToList();
            if (!animeElements.Any())
            {
                return new List<IAnimation>();
            }

            return animeElements.Select(a =>
            {
                if (GetAttributeValue(a, "name") == "shake")
                {
                    var shake = new Shake();

                    const string strengthAtt = "strength";
                    if (a.Attribute(strengthAtt) != null)
                    {
                        shake.Strength = int.Parse(GetAttributeValue(a, strengthAtt));
                    }

                    const string durationAtt = "duration";
                    if (a.Attribute(durationAtt) != null)
                    {
                        shake.Duration = int.Parse(GetAttributeValue(a, durationAtt));
                    }

                    return (IAnimation)shake;
                }

                throw new ArgumentException();
            }).ToList();
        }

        private static string GetAttributeValue(XElement targetElement, string attributeName)
        {
            var attribute = targetElement.Attribute(attributeName);
            return attribute == null ? string.Empty : attribute.Value;
        }
    }
}