using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using MyEnviroment.Platform.Common;

namespace MyEnvironment.Plugins.PluginOne
{

    public class PluginOneMainModel
    {
        [Import(typeof (IGetPluginName))] private IGetPluginName PluginNameGetterModel;

        public PluginOneMainModel()
        {
            var catalog = new DirectoryCatalog(Environment.CurrentDirectory);
            var container = new CompositionContainer(catalog);
            container.ComposeParts(this);
        }

        [Export("GetPluginName",typeof(Func<string>))]
        public string GetPluginName()
        {
            return PluginNameGetterModel.GetName();
        }
    }
}
