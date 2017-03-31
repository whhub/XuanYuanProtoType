using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using XAppFramework.Shared;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Module.PR
{
    [ModuleExport(typeof(PRModule))]
    public class PRModule : IModule
    {
        [Import]
        public ILogger Logger { get; set; }

        public void Initialize()
        {
            Logger.Log(LogType.DEV, LogLevel.INFO, "Initialize PRModule");
        }
    }
}
