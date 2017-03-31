using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace XAppFramework.Core.ViewRegistry
{
    public class ViewRegistryConfigEntry
    {
        [XmlAttribute("name")]
        public string Name { get; set; }

        [XmlAttribute("data-context-name")]
        public string DataContextName { get; set; }

        [XmlAttribute("region")]
        public string Region { get; set; }
    }
}
