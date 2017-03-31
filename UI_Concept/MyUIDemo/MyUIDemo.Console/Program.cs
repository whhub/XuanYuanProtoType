using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyUIDemo.Config;
using MyUIDemo.Framework;

namespace MyUIDemo.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            
            ModuleConfiguration config = new ModuleConfiguration();
            config.modules.Add(new ModuleInfo() { ModuleName = "ModuleA", ModuleType = typeof(ModuleInfo), AssemblyFile = "ModuleA.dll" });

            
            
            
        }
    }
}
