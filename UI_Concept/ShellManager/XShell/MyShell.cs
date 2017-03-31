/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/17/2017 12:20:01 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/17/2017 12:20:01 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using ShellManager.Interface;
using System.Windows.Controls;

namespace XShell
{
    public class MyShell : Window, IShell
    {
        public MyShell(string shellName)
        {
            _shellName = shellName;

            this.Loaded += new RoutedEventHandler(XShell_Loaded);

            this.Closed += new EventHandler(MyShell_Closed);
        }

        void MyShell_Closed(object sender, EventArgs e)
        {
            App.ShellManager.UnregisterShell(this);
        }

        void XShell_Loaded(object sender, RoutedEventArgs e)
        {
            App.ShellManager.RegisterShell(this);

            TextBlock content=new TextBlock();
            content.Text=_shellName;
            content.FontSize = 32;
            content.HorizontalAlignment = HorizontalAlignment.Center;
            content.VerticalAlignment = VerticalAlignment.Center;
            this.Content = content;
        }

        private string _shellName;
        public string ShellName
        {
            get {return _shellName; }
        }

        public bool ShowShell()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.Show();
            }));
            return true;
        }

        public bool HideShell()
        {
            this.Dispatcher.Invoke(new Action(() =>
            {
                this.Hide();
            }));
            return true;
        }
    }
}
