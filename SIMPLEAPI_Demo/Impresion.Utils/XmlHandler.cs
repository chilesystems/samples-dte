using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ThermalPrinting.XmlUtils
{
    public class XmlHandler
    {
        private string filePath;
        private XmlDocument xmlDocument;
        public XmlHandler(string filePath)
        {
            this.filePath = filePath;
            
            xmlDocument = new XmlDocument();
            using (System.IO.StreamReader reader = new System.IO.StreamReader(filePath, Encoding.GetEncoding("ISO-8859-1")))
                xmlDocument.Load(reader);            
        }

        public static string testXPath(string filePath, string xPathToTest)
        {
            var xmlDocument = new XmlDocument();
            xmlDocument.Load(filePath);

            var element = xmlDocument.SelectSingleNode(xPathToTest);
            if (element != null)
                return element.InnerText;
            return null;
        }

        public string getValue(string xpath, int index)
        {
            var newPath = string.Format(xpath, index);
            var element = xmlDocument.SelectSingleNode(newPath);
            if (element != null)
                return element.InnerText;
            return null;
        }
        public string getValue(string xpath)
        {
            var element = xmlDocument.SelectSingleNode(xpath);
            if (element != null)
                return element.InnerText;
            return null;
        }

        public int getValuesCount(string xpath)
        {
            var elements = xmlDocument.SelectNodes(xpath);
            if (elements != null)
                return elements.Count;
            return -1;
        }
    }
}
