/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/8/2017 11:41:59 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/8/2017 11:41:59 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xuanyuan.Interface
{
    public class PerformanceInfo
    {

        public double ProcessorTime { get; set; }

        public long TotalPhysicalMemory { get; set; }

        public long FreePhysicalMemory { get; set; }

        public long MemoryWorkingSet { get; set; }

        public long MemoryWorkingSetPrivate { get; set; }

        public double NetDatagrams { get; set; }

    }
}
