using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XAppFramework.Core.ViewRegistry
{
    class ViewRegistryConfigBuilder
    {
        public ViewRegistryConfig BuildFromXmlFile(string xmlFilePath)
        {
            XmlReader xmlReader = new XmlTextReader(xmlFilePath);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ViewRegistryConfig));
            Object obj = xmlSerializer.Deserialize(xmlReader);
            return obj as ViewRegistryConfig;
        }
    }
}
