/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/2/2017 9:46:55 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/2/2017 9:46:55 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Xuanyuan.Core
{
    public class Shell : Window
    {

        public string ShellName { get; protected set; }


        public virtual void Show(object context = null)
        {
            
        }

        public virtual void Hide(object context = null)
        {
            
        }

    }
}
