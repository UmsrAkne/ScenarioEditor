using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    public class TestChapter
    {
        [Test]
        public void タグからの生成テスト()
        {
            var xmlText = "<scenario>" +
                              "<chapter name=\"chA\" /><voice number=\"0\" /><text str=\"testText\" />" +
                          "</scenario>";

            var chapter = new Chapter(XElement.Parse(xmlText));
            Assert.AreEqual("chA", chapter.Name);
        }

        [Test]
        public void IsDefaultのテスト()
        {
            var xmlText = "<scenario>" +
                              "<chapter name=\"chA\" /><voice number=\"0\" /><text str=\"testText\" />" +
                          "</scenario>";

            var chapter = new Chapter(XElement.Parse(xmlText));
            Assert.IsFalse(chapter.IsDefault);

            var defaultChapter = new Chapter();
            Assert.IsTrue(defaultChapter.IsDefault);
        }
    }
}