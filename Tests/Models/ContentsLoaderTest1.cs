using System.IO;
using NUnit.Framework;
using ScenarioEditor.Models;

namespace Tests.Models
{
    public class ContentsLoaderTest
    {
        private readonly string testDirectoryName = "TestDirectory";
        private readonly string textDirectoryName = "texts";

        [SetUp]
        public void Setup()
        {
            Directory.CreateDirectory(testDirectoryName);
            Directory.CreateDirectory($@"{testDirectoryName}\{textDirectoryName}");

            var fs = File.CreateText($@"{testDirectoryName}\{textDirectoryName}\scenario.xml");
            fs.WriteLine("<root>");
            fs.WriteLine("<scenario><text string=\"テストテキスト\" /></scenario>");
            fs.WriteLine("</root>");

            fs.Close();
        }

        [TearDown]
        public void TearDown()
        {
            File.Delete($@"{testDirectoryName}\{textDirectoryName}\scenario.xml");

            Directory.Delete($@"{testDirectoryName}\{textDirectoryName}");
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
    }
}