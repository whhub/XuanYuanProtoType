using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using System.Threading;
using MyUIDemo.Component;
using System.Windows.Threading;
using System.Diagnostics;

namespace MyUIDemo
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        Thread uiThread;

        protected override void OnStartup(StartupEventArgs e)
        {
            //uiThread = new Thread(new ThreadStart(() =>
            //{

            //    ExamLM lmWin = new ExamLM();
            //    lmWin.Show();
            //    Dispatcher.Run();
            //}));
            //uiThread.SetApartmentState(ApartmentState.STA);
            //uiThread.Start();



            base.OnStartup(e);

            //UIConstructor uic = new UIConstructor();
            //uic.InitializeUI();

        }
    }
}
