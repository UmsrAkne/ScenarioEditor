using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class ImageTest
    {
        [Test]
        public void 引数なしコンストラクタのテスト()
        {
            var _ = new Image();
        }

        [Test]
        public void コンストラクタのテスト()
        {
            var xmlText = "<scenario>" +
                          "<image " +
                          "a=\"imageA\" b=\"imageB\" c=\"imageC\" d=\"imageD\" " +
                          "x=\"100\" y=\"200\" " +
                          "scale=\"1.5\" target=\"front\" />" +
                          "</scenario>";

            var image = new Image(XElement.Parse(xmlText));

            Assert.AreEqual("imageA", image.A);
            Assert.AreEqual("imageB", image.B);
            Assert.AreEqual("imageC", image.C);
            Assert.AreEqual("imageD", image.D);

            Assert.AreEqual(1.5, image.Scale);
            Assert.AreEqual(100, image.X);
            Assert.AreEqual(200, image.Y);
            Assert.AreEqual("front", image.Target);
        }

        [Test]
        public void Image要素を含まない場合のテスト()
        {
            // Image要素を含まない場合も例外が出ないか確認
            var _ = new Image(XElement.Parse("<scenario></scenario>"));
        }
    }
}