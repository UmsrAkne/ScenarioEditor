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
        private const string ImageDirectoryName = "images";

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

        public XmlDocument SettingXml { get; private set; }

        public List<FileInfo> VoiceFileInfos { get; private set; }

        public List<FileInfo> ImageFileInfos { get; private set; }

        public void LoadScenario()
        {
            ScenarioXml = LoadXml($@"{baseDirectoryInfo.FullName}\{TextDirectoryName}\scenario.xml");
        }

        public void LoadSetting()
        {
            SettingXml = LoadXml($@"{baseDirectoryInfo}\{TextDirectoryName}\setting.xml");
        }

        public void LoadVoiceFileList()
        {
            var voiceDirectoryInfo = new DirectoryInfo($@"{baseDirectoryInfo.FullName}\{VoiceDirectoryName}");

            VoiceFileInfos = voiceDirectoryInfo.GetFiles()
                .Where(info => string.Compare(info.Extension, ".ogg", StringComparison.OrdinalIgnoreCase) == 0)
                .OrderBy(info => info.Name)
                .ToList();
        }

        public void LoadImageFileList()
        {
            var imageDirectoryInfo = new DirectoryInfo($@"{baseDirectoryInfo.FullName}\{ImageDirectoryName}");

            ImageFileInfos = imageDirectoryInfo.GetFiles()
                .Where(info => string.Compare(info.Extension, ".png", StringComparison.OrdinalIgnoreCase) == 0)
                .OrderBy(info => info.Name)
                .ToList();
        }

        private XmlDocument LoadXml(string targetFilePath)
        {
            var doc = new XmlDocument();
            try
            {
                doc.Load(targetFilePath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return doc;
        }
    }
}