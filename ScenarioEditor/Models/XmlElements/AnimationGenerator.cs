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
                if (a.Attribute("name").Value == "shake")
                {
                    var shake = new Shake();

                    var strengthAtt = "strength";
                    shake.Strength = a.Attribute(strengthAtt) != null && a.Attribute(strengthAtt).Value != null
                        ? int.Parse(a.Attribute(strengthAtt).Value)
                        : shake.Strength;

                    var durationAtt = "duration";
                    shake.Duration = a.Attribute(durationAtt) != null && a.Attribute(durationAtt).Value != null
                        ? int.Parse(a.Attribute(durationAtt).Value)
                        : shake.Duration;

                    return (IAnimation)shake;
                }

                throw new ArgumentException();
            }).ToList();
        }
    }
}