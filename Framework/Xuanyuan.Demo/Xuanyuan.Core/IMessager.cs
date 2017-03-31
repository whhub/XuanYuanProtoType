/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/9/2017 11:17:38 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/9/2017 11:17:38 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xuanyuan.Core
{
    public interface IMessager
    {
        object Send(int id, object msg);

        void Register(int id, Func<object, object> func);
    }
}
