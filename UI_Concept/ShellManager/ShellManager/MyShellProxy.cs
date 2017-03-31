/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/17/2017 9:43:38 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/17/2017 9:43:38 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShellManager.Interface;
using ShellManager.Core;

namespace ShellManager
{
    public class MyShellProxy : IShell
    {
        MyCommunicator Proxy { get; set; }

        public string ProxyName { get; set; }

        public MyShellProxy(MyCommunicator proxy, string proxyName, string name)
        {
            Proxy = proxy;
            ProxyName = proxyName;

            _shellName = name;
        }

        private string _shellName;
        public string ShellName
        {
            get { return _shellName; }
        }

        public bool ShowShell()
        {
            Proxy.Send(ProxyName, ShellParam.MessageType.ShowShell, ShellName);
            return true;
        }

        public bool HideShell()
        {
            Proxy.Send(ProxyName, ShellParam.MessageType.HideShell, ShellName);
            return true;
        }
    }
}
