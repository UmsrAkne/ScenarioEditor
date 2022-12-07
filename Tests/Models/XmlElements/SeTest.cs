using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class SeTest
    {
        [Test]
        public void Voiceのデフォルトコンストラクタのテスト()
        {
            var _ = new Se();
        }

        [Test]
        public void Voiceのコンストラクタのテスト()
        {
            var xmlText1 = "<scenario><se number=\"1\" /></scenario>";
            var xmlText2 = "<scenario><se fileName=\"testName\" /></scenario>";
            var xmlText3 = "<scenario><se number=\"1\" repeatCount=\"10\" /></scenario>";

            var xml1 = XDocument.Parse(xmlText1).Element("scenario");
            var xml2 = XDocument.Parse(xmlText2).Element("scenario");
            var xml3 = XDocument.Parse(xmlText3).Element("scenario");

            var se1 = new Se(xml1);
            Assert.AreEqual(1, se1.Number);
            Assert.AreEqual(string.Empty, se1.FileName);

            var se2 = new Se(xml2);
            Assert.AreEqual(0, se2.Number);
            Assert.AreEqual("testName", se2.FileName);

            var se3 = new Se(xml3);
            Assert.AreEqual(10, se3.RepeatCount);
        }

        [Test]
        public void IsDefaultのテスト()
        {
            var xmlText1 = "<scenario><se number=\"1\" /></scenario>";
            var xmlText2 = "<scenario><se fileName=\"testName\" /></scenario>";
            var xml1 = XDocument.Parse(xmlText1).Element("scenario");
            var xml2 = XDocument.Parse(xmlText2).Element("scenario");

            var se1 = new Se(xml1);
            Assert.IsFalse(se1.IsDefault);

            var se2 = new Se(xml2);
            Assert.IsFalse(se2.IsDefault);

            var se3 = new Se();
            Assert.IsTrue(se3.IsDefault);
        }
    }
}