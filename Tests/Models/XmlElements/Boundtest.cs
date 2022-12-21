using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class TestBound
    {
        [Test]
        public void ToStringのテスト()
        {
            var bound = new Bound
            {
                Strength = 10,
                Duration = 20,
                Degree = 180,
                RepeatCount = 3,
            };

            Assert.AreEqual(bound.ToString(), "<anime name=\"bound\" strength=\"10\" degree=\"180\" duration=\"20\" repeatCount=\"3\" />");
        }
    }
}