using System.IO;
using NUnit.Framework;
using ScenarioEditor.Models;

namespace Tests.Models
{
    public class ContentsLoaderTest
    {
        private readonly string testDirectoryName = "TestDirectory";
        private readonly string textDirectoryName = "texts";
        private readonly string imageDirectoryName = "images";

        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(testDirectoryName);
            Directory.CreateDirectory($@"{testDirectoryName}\{textDirectoryName}");
            Directory.CreateDirectory($@"{testDirectoryName}\{imageDirectoryName}");

            var fs = File.CreateText($@"{testDirectoryName}\{textDirectoryName}\scenario.xml");
            fs.WriteLine("<root>");
            fs.WriteLine("<scenario><text string=\"テストテキスト\" /></scenario>");
            fs.WriteLine("</root>");
            fs.Close();

            var imageDirectoryPath = $@"{testDirectoryName}\{imageDirectoryName}";
            File.Create($@"{imageDirectoryPath}\A0101.png").Close();
            File.Create($@"{imageDirectoryPath}\B0101.png").Close();
            File.Create($@"{imageDirectoryPath}\C0101.png").Close();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete($@"{testDirectoryName}\{textDirectoryName}\scenario.xml");

            var imageDirectoryPath = $@"{testDirectoryName}\{imageDirectoryName}";
            File.Delete($@"{imageDirectoryPath}\A0101.png");
            File.Delete($@"{imageDirectoryPath}\B0101.png");
            File.Delete($@"{imageDirectoryPath}\C0101.png");

            Directory.Delete($@"{testDirectoryName}\{textDirectoryName}");
            Directory.Delete($@"{testDirectoryName}\{imageDirectoryName}");
            Directory.Delete(testDirectoryName);
        }

        [Test]
        public void シナリオファイルの読み込みテスト()
        {
            var loader = new ContentsLoader(testDirectoryName);

            Assert.IsNull(loader.ScenarioXml, "デフォルトはNull");

            loader.LoadScenario();
            Assert.NotNull(loader.ScenarioXml, "ロードが正常に行われれば値が入っている");
        }

        [Test]
        public void サウンドファイルリストの取得テスト()
        {
            var voiceDirectoryPath = $@"{testDirectoryName}\voices";
            Directory.CreateDirectory(voiceDirectoryPath);
            File.Create($@"{voiceDirectoryPath}\01.wav").Close();
            File.Create($@"{voiceDirectoryPath}\02.ogg").Close();
            File.Create($@"{voiceDirectoryPath}\03.OGG").Close();
            File.Create($@"{voiceDirectoryPath}\04.Ogg").Close();

            var loader = new ContentsLoader(testDirectoryName);
            Assert.IsNull(loader.VoiceFileInfos, "デフォルトはnull");

            loader.LoadVoiceFileList();
            Assert.NotNull(loader.VoiceFileInfos);
            Assert.AreEqual(3,loader.VoiceFileInfos.Count, "期待通りなら、.wav 以外の3ファイルが認識される");

            File.Delete($@"{voiceDirectoryPath}\01.wav");
            File.Delete($@"{voiceDirectoryPath}\02.ogg");
            File.Delete($@"{voiceDirectoryPath}\03.OGG");
            File.Delete($@"{voiceDirectoryPath}\04.Ogg");
            Directory.Delete(voiceDirectoryPath);
        }

        [Test]
        public void 画像ファイルリストの取得テスト()
        {
            var loader = new ContentsLoader(testDirectoryName);
            Assert.IsNull(loader.ImageFileInfos);

            loader.LoadImageFileList();
            Assert.NotNull(loader.ImageFileInfos);
            Assert.AreEqual(3, loader.ImageFileInfos.Count);
        }
    }
}