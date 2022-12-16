using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class ShakeTest
    {
        [Test]
        public void ToStringのテスト()
        {
            var shake = new Shake
            {
                Strength = 90,
                Duration = 120
            };

            Assert.AreEqual(shake.ToString(), "<anime name=\"shake\" strength=\"90\" duration=\"120\" />");
        }
    }
}