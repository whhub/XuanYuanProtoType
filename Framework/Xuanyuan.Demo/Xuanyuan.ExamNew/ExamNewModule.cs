/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/9/2017 2:02:52 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/9/2017 2:02:52 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.Regions;

namespace Xuanyuan.ExamNew
{
    [ModuleExport(typeof(ExamNewModule), InitializationMode = InitializationMode.WhenAvailable)]
    public class ExamNewModule:IModule
    {
        private readonly IRegionViewRegistry regionViewRegistry;

        [ImportingConstructor]
        public ExamNewModule(IRegionViewRegistry registry)
        {
            regionViewRegistry = registry;
        }

        public void Initialize()
        {
            if (regionViewRegistry != null)
            {
                regionViewRegistry.RegisterViewWithRegion("Exam", typeof(ExamNew));
                //regionViewRegistry.RegisterViewWithRegion("Exam", typeof(Exam));

            }
        }
    }
}
