using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class DrawTest
    {
        [Test]
        public void 引数なしコンストラクタのテスト()
        {
            var draw = new Draw();
        }

        [Test]
        public void コンストラクタのテスト()
        {
            var xmlText = "<scenario>" +
                          "<draw " +
                          "a=\"imageA\" b=\"imageB\" c=\"imageC\" d=\"imageD\" " +
                          "x=\"100\" y=\"200\" " +
                          "scale=\"1.5\" target=\"front\" />" +
                          "</scenario>";

            var draw = new Draw(XElement.Parse(xmlText));

            Assert.AreEqual("imageA", draw.A);
            Assert.AreEqual("imageB", draw.B);
            Assert.AreEqual("imageC", draw.C);
            Assert.AreEqual("imageD", draw.D);

            Assert.AreEqual("front", draw.Target);
        }

        [Test]
        public void Draw要素を含まない場合のテスト()
        {
            // Draw要素を含まない場合も例外が出ないか確認
            var _ = new Draw(XElement.Parse("<scenario></scenario>"));
        }

        [Test]
        public void ToStringのテスト()
        {
            var xmlText = "<scenario>" +
                          "<draw " +
                          "a=\"imageA\" b=\"imageB\" c=\"imageC\" d=\"imageD\" " +
                          "target=\"front\" />" +
                          "</scenario>";

            Assert.AreEqual(
                "<draw a=\"imageA\" b=\"imageB\" c=\"imageC\" d=\"imageD\" target=\"front\" />",
                new Draw(new XElement(XElement.Parse(xmlText))).ToString());

            // Draw の情報が無い場合は 空文字が返る
            Assert.AreEqual(string.Empty, new Draw(XElement.Parse("<scenario></scenario>")).ToString());
            Assert.AreEqual(string.Empty, new Draw().ToString());
        }
    }
}