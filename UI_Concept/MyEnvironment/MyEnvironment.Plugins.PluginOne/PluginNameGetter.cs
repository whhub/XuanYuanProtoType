using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MyEnvironment.Plugins.PluginOne
{
    [Export(typeof(IGetPluginName))]
    public class PluginNameGetter : IGetPluginName
    {
        #region Implementation of IGetPluginName

        public string GetName()
        {
            return "PluginOne";
        }

        #endregion
    }
}

