/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/16/2017 5:48:38 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/16/2017 5:48:38 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShellManager.Interface
{
    public interface ICommunicator
    {
        string Send(string target,string messageType, string message);

        event Action<string,string, string> MessageReceived;
    }
}
