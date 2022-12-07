using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class TextTest
    {
        [Test]
        public void デフォルトコンストラクタのテスト()
        {
            var t = new Text();
        }

        [Test]
        public void コンストラクタのテスト()
        {
            var xml1 = XDocument.Parse("<scenario><text string=\"テスト用テキスト１\" /></scenario>").Element("scenario");
            var xml2 = XDocument.Parse("<scenario><text str=\"テスト用テキスト２\" /></scenario>").Element("scenario");

            Assert.AreEqual(new Text(xml1).Str, "テスト用テキスト１");
            Assert.AreEqual(new Text(xml2).Str, "テスト用テキスト２");
        }

        [Test]
        public void ToStringのテスト()
        {
            var xml1 = XDocument.Parse("<scenario><text string=\"テスト用テキスト１\" /></scenario>").Element("scenario");
            var xml2 = XDocument.Parse("<scenario><text str=\"テスト用テキスト２\" /></scenario>").Element("scenario");

            Assert.AreEqual("<text str=\"テスト用テキスト１\" />", new Text(xml1).ToString());
            Assert.AreEqual("<text str=\"テスト用テキスト２\" />", new Text(xml2).ToString());
        }
    }
}