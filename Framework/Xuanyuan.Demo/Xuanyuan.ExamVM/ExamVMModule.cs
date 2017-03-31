/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/7/2017 4:48:57 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/7/2017 4:48:57 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Xuanyuan.Core;
using System.ComponentModel.Composition;

namespace Xuanyuan.ExamVM
{
    [ModuleExport(typeof(ExamVMModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ExamVMModule : IModule
    {
        public ExamVMModule()
        {

        }

        public void Initialize()
        {
            
        }
        
    }
}
