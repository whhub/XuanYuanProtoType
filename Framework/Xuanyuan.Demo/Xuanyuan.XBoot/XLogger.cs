/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/7/2017 9:54:23 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/7/2017 9:54:23 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Logging;
using System.ComponentModel.Composition;
using Xuanyuan.Core;

namespace Xuanyuan.XBoot
{

    [Export(typeof(ILogger))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XLogger : ILoggerFacade, ILogger
    {
        public void Log(string message, Category category, Priority priority)
        {

        }


        public XLogger()
        {
        }

        public void Log(string log)
        {
            Console.WriteLine("{0}", log);
            System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace();
            System.Diagnostics.StackFrame[] sfs = st.GetFrames();
            for (int i = 1; i < 3; i++)
            {
                System.Diagnostics.StackFrame sf = sfs[i];
                string methodName = sf.GetMethod().Name;
                string className = sf.GetMethod().DeclaringType.Name;
                Console.WriteLine("\t{0}::{1}", className, methodName);
            }
        }

        public void SetInfo(string source)
        {
            
        }
    }
}
