/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/9/2017 11:19:46 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/9/2017 11:19:46 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xuanyuan.Core
{
    public interface ILogger
    {
        void SetInfo(string source);

        void Log(string log);
    }
}
