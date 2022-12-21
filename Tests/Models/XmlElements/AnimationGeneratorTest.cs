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

            Assert.AreEqual(1, animations.Count);

            var shake = (Shake)animations[0];
            Assert.AreEqual("shake",shake.Name);
            Assert.AreEqual(20, shake.Strength);
            Assert.AreEqual(15, shake.Duration);
        }

        [Test]
        public void Slideの生成テスト()
        {
            var xmlText = "<scenario>" +
                              "<anime name=\"slide\" speed=\"10.0\" degree=\"90\" distance=\"15\" />" +
                          "</scenario>";

            var animations = AnimationGenerator.GetAnimation(XElement.Parse(xmlText));

            Assert.AreEqual(1, animations.Count);

            var slide = (Slide)animations.First();
            Assert.AreEqual("slide", slide.Name);
            Assert.AreEqual(10.0, slide.Speed);
            Assert.AreEqual(90, slide.Degree);
            Assert.AreEqual(15, slide.Distance);
        }

        [Test]
        public void Boundの生成テスト()
        {
            var xmlText = "<scenario>" +
                              "<anime name=\"bound\" strength=\"10\" duration=\"90\" degree=\"15\" repeatCount=\"2\" />" +
                          "</scenario>";

            var animations = AnimationGenerator.GetAnimation(XElement.Parse(xmlText));

            Assert.AreEqual(1, animations.Count);

            var bound = (Bound)animations.First();
            Assert.AreEqual("bound", bound.Name);
            Assert.AreEqual(10, bound.Strength);
            Assert.AreEqual(90, bound.Duration);
            Assert.AreEqual(15, bound.Degree);
            Assert.AreEqual(2, bound.RepeatCount);
        }

        [Test]
        public void Flashの生成テスト()
        {
            var xmlText = "<scenario>" +
                              "<anime name=\"flash\" duration=\"10\" cycle=\"90\" alpha=\"0.5\" repeatCount=\"2\" />" +
                          "</scenario>";

            var animations = AnimationGenerator.GetAnimation(XElement.Parse(xmlText));

            Assert.AreEqual(1, animations.Count);

            var flash = (Flash)animations.First();
            Assert.AreEqual("flash", flash.Name);
            Assert.AreEqual(10, flash.Duration);
            Assert.AreEqual(90, flash.Cycle);
            Assert.AreEqual(0.5, flash.Alpha);
            Assert.AreEqual(2, flash.RepeatCount);
        }

        [Test]
        public void AlphaChangerの生成テスト()
        {
            var xmlText = "<scenario>" +
                              "<anime name=\"alphaChanger\" amount=\"0.5\"  />" +
                          "</scenario>";

            var animations = AnimationGenerator.GetAnimation(XElement.Parse(xmlText));

            Assert.AreEqual(1, animations.Count);

            var alphaChanger = (AlphaChanger)animations.First();
            Assert.AreEqual("alphaChanger", alphaChanger.Name);
            Assert.AreEqual(0.5, alphaChanger.Amount);
        }
    }
}