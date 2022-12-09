using System.Collections.Generic;
using System.IO;
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

        [Test]
        public void ToStringのテスト()
        {
            var xmlText = "<scenario>" +
                          "<image " +
                          "a=\"imageA\" b=\"imageB\" c=\"imageC\" d=\"imageD\" " +
                          "x=\"100\" y=\"200\" " +
                          "scale=\"1.5\" target=\"front\" />" +
                          "</scenario>";

            Assert.AreEqual(
                "<image a=\"imageA\" b=\"imageB\" c=\"imageC\" d=\"imageD\" scale=\"1.5\" x=\"100\" y=\"200\" target=\"front\" />",
                new Image(new XElement(XElement.Parse(xmlText))).ToString()
            );

            // Image の情報が無い場合は 空文字が返る
            Assert.AreEqual(string.Empty, new Image(XElement.Parse("<scenario></scenario>")).ToString());
            Assert.AreEqual(string.Empty, new Image().ToString());
        }

        [Test]
        public void ChangeImageCommandのテスト()
        {
            var image = new Image
            {
                ImageFiles = new List<FileInfo>()
                {
                    new FileInfo("A0101.png"),
                    new FileInfo("A0102.png"),
                    new FileInfo("A0103.png"),
                },
                A = "A0101",
            };

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0102", image.A );

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0103", image.A );

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0101", image.A );
        }

        [Test]
        public void ChangeImageCommand空文字の場合のテスト()
        {
            var image = new Image
            {
                ImageFiles = new List<FileInfo>()
                {
                    new FileInfo("A0101.png"),
                    new FileInfo("A0102.png"),
                    new FileInfo("A0103.png"),
                },
                A = string.Empty,
            };

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0101", image.A );

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0102", image.A );

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0103", image.A );
        }

        [Test]
        public void ChangeImageCommandのテストABCD()
        {
            var image = new Image
            {
                ImageFiles = new List<FileInfo>()
                {
                    new FileInfo("A0101.png"),
                    new FileInfo("A0102.png"),
                    new FileInfo("B0101.png"),
                    new FileInfo("B0102.png"),
                    new FileInfo("C0101.png"),
                    new FileInfo("C0102.png"),
                    new FileInfo("D0101.png"),
                    new FileInfo("D0102.png"),
                },
                A = "A0101",
                B = "B0101",
                C = "C0101",
                D = "D0101",
            };

            image.ChangeImageToNextCommand.Execute("A");
            Assert.AreEqual("A0102", image.A );

            image.ChangeImageToNextCommand.Execute("B");
            Assert.AreEqual("B0102", image.B );

            image.ChangeImageToNextCommand.Execute("C");
            Assert.AreEqual("C0102", image.C );

            image.ChangeImageToNextCommand.Execute("D");
            Assert.AreEqual("D0102", image.D );
        }
    }
}