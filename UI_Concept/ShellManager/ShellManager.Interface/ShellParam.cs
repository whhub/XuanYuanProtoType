/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/17/2017 9:28:09 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/17/2017 9:28:09 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShellManager.Interface
{
    public class ShellParam
    {

        public const string ShellServerProxyName = "ShellManager";

        public const int ShellServerProxyPort = 10100;

        public const int ShellManagerCommandID = 88888;


        public class MessageType
        {
            public const string RegisterShell = "RegisterShell";
            public const string UnregisterShell = "UnregisterShell";
            public const string ShowShell = "ShowShell";
            public const string HideShell = "HideShell";
        }
    }
}
