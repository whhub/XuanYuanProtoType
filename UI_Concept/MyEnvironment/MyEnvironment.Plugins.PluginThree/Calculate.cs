using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using MyEnviroment.Platform.Common;

namespace MyEnvironment.Plugins.PluginThree
{
    [Export(typeof(ICalculate))]
    public class Calculate : ICalculate
    {
        #region Implementation of ICalculate

        public int Add(int oper1, int oper2)
        {
            return oper1 + oper2;
        }
        #endregion
    }

}
