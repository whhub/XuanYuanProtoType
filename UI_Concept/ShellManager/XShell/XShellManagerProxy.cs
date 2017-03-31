/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/17/2017 12:24:27 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/17/2017 12:24:27 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShellManager.Interface;
using ShellManager.Core;

namespace XShell
{
    public class XShellManagerProxy:IShellManager
    {
        

        private MyCommunicator _proxy;

        public XShellManagerProxy(string proxyName, int port)
        {
            ShellCollection = new Dictionary<string, IShell>();

            _proxy = new MyCommunicator(proxyName, port);
            _proxy.MessageReceived += new Action<string, string, string>(_proxy_MessageReceived);
        }

        private void _proxy_MessageReceived(string sender, string messageType, string message)
        {
            if (!string.IsNullOrWhiteSpace(messageType) & !string.IsNullOrWhiteSpace(message))
            {
                IShell shell = GetShell(message);
                if (shell != null)
                {
                    if (messageType.Equals(ShellParam.MessageType.ShowShell))
                    {
                        shell.ShowShell();
                    }
                    else if (messageType.Equals(ShellParam.MessageType.HideShell))
                    {
                        shell.HideShell();
                    }
                }
            }
        }

        public IDictionary<string, IShell> ShellCollection { get; set; }

        public bool RegisterShell(IShell shell)
        {
            string shellName = shell.ShellName;
            _proxy.Send(ShellParam.ShellServerProxyName,ShellParam.MessageType.RegisterShell, shellName);
            ShellCollection.Add(shellName, shell);
            return true;
        }

        public bool UnregisterShell(IShell shell)
        {
            string shellName = shell.ShellName;
            _proxy.Send(ShellParam.ShellServerProxyName, ShellParam.MessageType.UnregisterShell, shellName);
            ShellCollection.Remove(shellName);
            return true;
        }

        public IShell GetShell(string shellname)
        {
            if (ShellCollection.Keys.Contains(shellname))
                return ShellCollection[shellname];

            return null;
        }
    }
}
