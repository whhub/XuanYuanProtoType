using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace XAppFramework.Core.ViewRegistry
{
    [XmlRoot("view-registry-config")]
    public class ViewRegistryConfig
    {
        [XmlArray("views"), XmlArrayItem("view")]
        public ViewRegistryConfigEntry[] Entries { get; set; }
    }
}
