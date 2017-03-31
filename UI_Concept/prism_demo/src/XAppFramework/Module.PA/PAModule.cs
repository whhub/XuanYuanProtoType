using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.Windows;
using XAppFramework.Shared;
using System.ComponentModel.Composition.Hosting;

namespace Module.PA
{
    [ModuleExport(typeof(PAModule))]
    public class PAModule : IModule
    {
       

        [Import]
        public ILogger Logger { get; set; }
 
        public void Initialize()
        {
            Logger.Log(LogType.DEV, LogLevel.INFO, "Initialize PAModule");
        }
    }
}
