using System.Linq;
using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    public class AnimationGeneratorTest
    {
        [Test]
        public void TestGeAnimation()
        {
            var xmlText = "<scenario>" +
                              "<anime name=\"shake\" strength=\"20\" duration=\"15\" />" +
                          "</scenario>";

            var animations = AnimationGenerator.GetAnimation(XElement.Parse(xmlText));

            Assert.AreEqual(1,animations.Count);

            var shake = (Shake)animations[0];
            Assert.AreEqual("shake",shake.Name);
            Assert.AreEqual(20,shake.Strength);
            Assert.AreEqual(15,shake.Duration);
        }
    }
}