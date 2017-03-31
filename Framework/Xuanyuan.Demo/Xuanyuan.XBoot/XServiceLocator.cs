/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/7/2017 9:57:30 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/7/2017 9:57:30 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.ServiceLocation;

namespace Xuanyuan.XBoot
{
    public class XServiceLocator : ServiceLocatorImplBase
    {



        protected override IEnumerable<object> DoGetAllInstances(Type serviceType)
        {
            List<object> allInstance=new List<object>();
            allInstance.Add(default(Type));
            return allInstance;
        }

        protected override object DoGetInstance(Type serviceType, string key)
        {
            return default(Type);
        }
    }
}
