using NUnit.Framework;
using ScenarioEditor.Models.XmlElements;

namespace Tests.Models.XmlElements
{
    [TestFixture]
    public class BackgroundVoiceTest
    {
        [Test]
        public void ToStringのテスト()
        {
            var bgv = new BackgroundVoice
            {
                Names = "fileA, fileB, fileC",
                Channel = 2
            };

            Assert.AreEqual("<backgroundVoice names=\"fileA, fileB, fileC\" channel=\"2\" />", bgv.ToString());
        }
    }
}