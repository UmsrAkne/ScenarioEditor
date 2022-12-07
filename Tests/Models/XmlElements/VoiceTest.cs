using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class VoiceTest
    {
        [Test]
        public void Voiceのデフォルトコンストラクタのテスト()
        {
            var _ = new Voice();
        }

        [Test]
        public void Voiceのコンストラクタのテスト()
        {
            var xmlText1 = "<scenario><voice number=\"1\" /></scenario>";
            var xmlText2 = "<scenario><voice fileName=\"testName\" /></scenario>";
            var xml1 = XDocument.Parse(xmlText1).Element("scenario");
            var xml2 = XDocument.Parse(xmlText2).Element("scenario");

            var v1 = new Voice(xml1);
            Assert.AreEqual(1, v1.Number);
            Assert.AreEqual(string.Empty, v1.FileName);

            var v2 = new Voice(xml2);
            Assert.AreEqual(0, v2.Number);
            Assert.AreEqual("testName", v2.FileName);
        }

        [Test]
        public void ToStringのテスト()
        {
            var xmlText1 = "<scenario><voice number=\"1\" /></scenario>";
            var xmlText2 = "<scenario><voice fileName=\"testName\" /></scenario>";
            var xml1 = XDocument.Parse(xmlText1).Element("scenario");
            var xml2 = XDocument.Parse(xmlText2).Element("scenario");

            Assert.AreEqual("<voice number=\"1\" />", new Voice(xml1).ToString());
            Assert.AreEqual("<voice fileName=\"testName\" />", new Voice(xml2).ToString());
        }
    }
}