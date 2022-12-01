using System;
using System.IO;
using System.Xml;

namespace ScenarioEditor.Models
{
    public class ContentsLoader
    {
        private const string TextDirectoryName = "texts";

        private readonly DirectoryInfo baseDirectoryInfo;

        public ContentsLoader(string baseDirectoryPath)
        {
            if (!Directory.Exists(baseDirectoryPath))
            {
                throw new DirectoryNotFoundException();
            }

            baseDirectoryInfo = new DirectoryInfo(baseDirectoryPath);
        }

        public XmlDocument ScenarioXml { get; private set; }

        public void LoadScenario()
        {
            var xmlDocumentPath = $@"{baseDirectoryInfo.FullName}\{TextDirectoryName}\scenario.xml";

            var doc = new XmlDocument();
            try
            {
                doc.Load(xmlDocumentPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            ScenarioXml = doc;
        }
    }
}