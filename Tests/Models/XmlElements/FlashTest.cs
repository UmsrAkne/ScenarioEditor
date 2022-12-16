using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class FlashTest
    {
        [Test]
        public void ToStringのテスト()
        {
            var flash = new Flash
            {
                Cycle = 10,
                Duration = 20,
                RepeatCount = 3
            };

            Assert.AreEqual(flash.ToString(), "<anime name=\"flash\" cycle=\"10\" duration=\"20\" repeatCount=\"3\" />");
        }
    }
}