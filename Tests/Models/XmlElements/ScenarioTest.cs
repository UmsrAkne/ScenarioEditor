using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class ScenarioTest
    {
        [Test]
        public void 引数なしコンストラクタのテスト()
        {
            var _ = new Scenario();
        }

        [Test]
        public void コンストラクタのテスト()
        {
            var xmlText = "<scenario>" +
                          "<text str=\"testText\" />" +
                          "<voice fileName=\"soundFile\" />" +
                          "<image a=\"imageA\" b=\"imageB\" />" +
                          "</scenario>";

            var scenario = new Scenario(XElement.Parse(xmlText));

            Assert.NotNull(scenario.Voice);
            Assert.NotNull(scenario.Image);
            Assert.NotNull(scenario.Text);
        }
    }
}