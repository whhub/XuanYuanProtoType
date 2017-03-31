/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>12/8/2016 4:53:58 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>12/8/2016 4:53:58 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace MyUIDemo.Framework
{
    [Serializable]
    public class ModuleInfo
    {
        [XmlAttribute(AttributeName = "assemblyFile")]
        public string AssemblyFile { get; set; }

        [XmlAttribute(AttributeName = "moduleType")]
        public Type ModuleType { get; set; }

        [XmlAttribute(AttributeName = "moduleName")]
        public string ModuleName { get; set; }

        public bool IsLazy { get; set; }

    }
}
