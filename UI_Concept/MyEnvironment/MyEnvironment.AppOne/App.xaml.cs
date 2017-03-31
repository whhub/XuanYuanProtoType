using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using MyEnviroment.Platform.Common;

namespace MyEnvironment.AppOne
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var temp = new StartUper<MainWindow>();
            this.MainWindow = temp.Window;
            this.MainWindow.Show();
        }
    }
}
