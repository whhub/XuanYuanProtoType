using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace XShell
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static XShellManagerProxy ShellManager { get; protected set; }

        protected override void OnStartup(StartupEventArgs e)
        {

            base.OnStartup(e);

            string name = e.Args[0];
            int proxyPort =int.Parse(e.Args[1]);

            double width = double.Parse(e.Args[2]);
            double height = double.Parse(e.Args[3]);

            ShellManager = new XShellManagerProxy(name, proxyPort);


            MyShell shell= new MyShell(name);
            shell.Width = width;
            shell.Height = height;

            this.MainWindow = shell;
            shell.Show();
        }
    }
}
