using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace ScenarioEditor.Models
{
    public class ContentsLoader
    {
        private const string TextDirectoryName = "texts";
        private const string VoiceDirectoryName = "voices";

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

        public List<FileInfo> VoiceFileInfos { get; private set; }

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

        public void LoadVoiceFileList()
        {
            var voiceDirectoryInfo = new DirectoryInfo($@"{baseDirectoryInfo.FullName}\{VoiceDirectoryName}");

            VoiceFileInfos = voiceDirectoryInfo.GetFiles()
                .Where(info => string.Compare(info.Extension, ".ogg", StringComparison.OrdinalIgnoreCase) == 0)
                .OrderBy(info => info.Name)
                .ToList();
        }
    }
}