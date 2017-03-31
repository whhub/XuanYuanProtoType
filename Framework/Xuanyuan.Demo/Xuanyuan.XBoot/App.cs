/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/7/2017 2:22:22 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/7/2017 2:22:22 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Xuanyuan.XBoot
{
    public class App :Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            XBootstrapper boot = new XBootstrapper();
            boot.Run();
        }
    }
}
