using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace XAppFramework
{
    public class App : Application
    {
        AppBootstrapper _bootstrapper = new AppBootstrapper();

        public void ConfigureModuleCatalog(string xmlFilePath)
        {
            _bootstrapper.ConfigureModuleCatalog(xmlFilePath);
        }

        public void ConfigureViewRegistry(string xmlFilePath)
        {
            _bootstrapper.ConfigureViewRegistry(xmlFilePath);
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _bootstrapper.Run();
        }
    }
}
