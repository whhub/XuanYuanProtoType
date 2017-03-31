using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XAppFramework;

namespace Boot
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            App app = new App();
            app.ConfigureModuleCatalog(@"..\appdata\app_module\modules.xml");
            app.ConfigureViewRegistry(@"..\appdata\app_module\view_registry.xml");
            app.ShutdownMode = System.Windows.ShutdownMode.OnLastWindowClose;
            app.Run();
        }
    }
}
