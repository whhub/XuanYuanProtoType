using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using MyEnviroment.Platform.Common;

namespace MyEnvironment.Plugins.PluginThree
{
   public class PluginThreeMainModel
    {
       [Import(typeof(ICalculate))]
       private ICalculate CalculateModel;

       public PluginThreeMainModel()
       {
           var catalog = new DirectoryCatalog(Environment.CurrentDirectory);
           var container = new CompositionContainer(catalog);
           container.ComposeParts(this);
       }

       [Export("Add", typeof(Func<int, int, int>))]
       public int Add(int oper1, int oper2)
       {
           return CalculateModel.Add(oper1, oper2);
       }
    }
}
