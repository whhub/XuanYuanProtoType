using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System.Windows.Controls;
using Microsoft.Practices.Prism.Regions;

namespace Module.Ref
{
    [ModuleExport(typeof(RefModule))]
    class RefModule : IModule
    {
       
        public void Initialize()
        {
        }
    }
}
