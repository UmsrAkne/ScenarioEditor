using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class AlphaChangerTest
    {
        [Test]
        public void ToStringのテスト()
        {
            var alphaChanger = new AlphaChanger()
            {
                Amount = 0.1,
            };

            Assert.AreEqual(alphaChanger.ToString(), "<anime name=\"alphaChanger\" amount=\"0.1\" />");
        }
    }
}