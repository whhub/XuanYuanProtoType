/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/16/2017 4:59:08 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/16/2017 4:59:08 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ShellManager.Interface
{
    public interface IShellManager
    {
        IDictionary<string, IShell> ShellCollection { get; set; }

        bool RegisterShell(IShell shell);

        bool UnregisterShell(IShell shell);

        IShell GetShell(string shellname);
    }
}
