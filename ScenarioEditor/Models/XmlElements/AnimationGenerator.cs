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
                var shake = new Shake();
                if (GetAttributeValue(a, "name") == shake.Name)
                {
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

                var slide = new Slide();
                if (GetAttributeValue(a, "name") == slide.Name)
                {
                    var speedAtt = nameof(slide.Speed).ToLower();
                    if (a.Attribute(speedAtt) != null)
                    {
                        slide.Speed = double.Parse(GetAttributeValue(a, speedAtt));
                    }

                    var distanceAtt = nameof(slide.Distance).ToLower();
                    if (a.Attribute(distanceAtt) != null)
                    {
                        slide.Distance = int.Parse(GetAttributeValue(a, distanceAtt));
                    }

                    var degreeAtt = nameof(slide.Degree).ToLower();
                    if (a.Attribute(degreeAtt) != null)
                    {
                        slide.Degree = int.Parse(GetAttributeValue(a, degreeAtt));
                    }

                    return (IAnimation)slide;
                }

                var bound = new Bound();
                if (GetAttributeValue(a, "name") == bound.Name)
                {
                    var durationAtt = nameof(bound.Duration).ToLower();
                    if (a.Attribute(durationAtt) != null)
                    {
                        bound.Duration = int.Parse(GetAttributeValue(a, durationAtt));
                    }

                    var degreeAtt = nameof(bound.Degree).ToLower();
                    if (a.Attribute(degreeAtt) != null)
                    {
                        bound.Degree = int.Parse(GetAttributeValue(a, degreeAtt));
                    }

                    var strengthAtt = nameof(bound.Strength).ToLower();
                    if (a.Attribute(strengthAtt) != null)
                    {
                        bound.Strength = int.Parse(GetAttributeValue(a, strengthAtt));
                    }

                    var repeatCountAtt = nameof(bound.RepeatCount);
                    repeatCountAtt = char.ToLower(repeatCountAtt.First()) + repeatCountAtt.Substring(1); // ToLowerCamel
                    if (a.Attribute(repeatCountAtt) != null)
                    {
                        bound.RepeatCount = int.Parse(GetAttributeValue(a, repeatCountAtt));
                    }

                    return bound;
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