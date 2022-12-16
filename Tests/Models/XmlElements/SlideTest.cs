using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class SlideTest
    {
        [Test]
        public void ToStringのテスト()
        {
            var slide = new Slide
            {
                Degree = 120,
                Distance = 20,
                Speed = 15,
                RepeatCount = 3
            };

            Assert.AreEqual(slide.ToString(), "<anime name=\"slide\" speed=\"15\" degree=\"120\" distance=\"20\" repeatCount=\"3\" />");
        }
    }
}