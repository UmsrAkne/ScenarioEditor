using System.Xml.Linq;
using NUnit.Framework;
using ScenarioEditor.Models;

namespace Tests.Models
{
    public class ScenarioListTest
    {
        [Test]
        public void Loadのテスト()
        {
            var xmlText = "<root>" +
                          "<scenario>   <voice number=\"1\" />  <text str=\"testText1\" />   </scenario>" +
                          "<scenario>   <voice number=\"2\" />  <text str=\"testText2\" />   </scenario>" +
                          "<scenario>   <voice number=\"3\" />  <text str=\"testText3\" />   </scenario>" +
                          "<scenario>   <voice number=\"4\" />  <text str=\"testText4\" />   </scenario>" +
                          "</root>";

            var scenarioList = new ScenarioList();
            scenarioList.Load(XDocument.Parse(xmlText));
        }
    }
}