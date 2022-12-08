using System.Linq;
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
            Assert.NotNull(scenario.Text);
            Assert.AreEqual(1,scenario.Images.Count);
        }

        [Test]
        public void ToStringのテストImageTagなし()
        {
            var scenario = new Scenario
            {
                Voice = new Voice() { FileName = "testFile" },
                Text = new Text { Str = "testText" },
            };

            Assert.AreEqual(
                "<scenario><voice fileName=\"testFile\" /><text str=\"testText\" /></scenario>",
                scenario.ToString()
                );
        }

        [Test]
        public void ToStringのテストImageTagなしIgnoreつき()
        {
            var scenario = new Scenario
            {
                Voice = new Voice() { FileName = "testFile" },
                Text = new Text { Str = "testText" },
            };

            scenario.Ignore = true;

            Assert.AreEqual(
                "<scenario><ignore /><voice fileName=\"testFile\" /><text str=\"testText\" /></scenario>",
                scenario.ToString()
                );
        }


        [Test]
        public void ToStringのテストImageTagあり()
        {
            var scenario = new Scenario
            {
                Voice = new Voice() { FileName = "testFile" },
                Text = new Text { Str = "testText" },
            };

            scenario.Images.Add(new Image());
            scenario.Images.First().A = "imageA";

            Assert.AreEqual(
                "<scenario><voice fileName=\"testFile\" /><text str=\"testText\" />\r\n" +
                "\t<image a=\"imageA\" b=\"\" c=\"\" d=\"\" scale=\"1\" x=\"0\" y=\"0\" target=\"main\" />\r\n" +
                "</scenario>",
                scenario.ToString()
                );
        }
    }
}