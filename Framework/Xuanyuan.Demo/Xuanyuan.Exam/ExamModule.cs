/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/6/2017 4:27:41 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/6/2017 4:27:41 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.ViewModel;

namespace Xuanyuan.Exam
{
    [ModuleExport(typeof(ExamModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ExamModule : IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ExamModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }

        public void Initialize()
        {
            if (regionViewRegistry != null)
            {
                regionViewRegistry.RegisterViewWithRegion("Exam", typeof(Exam));
                //regionViewRegistry.RegisterViewWithRegion("Exam", typeof(Exam));
            }
        }
    }

    public class MyVM : NotificationObject
    {

    }
}
