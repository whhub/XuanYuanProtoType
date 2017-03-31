/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/6/2017 4:42:14 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/6/2017 4:42:14 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.MefExtensions;
using System.Windows;
using Microsoft.Practices.ServiceLocation;
using Xuanyuan.Core;

namespace Xuanyuan.XBoot
{
    public class XBootstrapper : MefBootstrapper
    {

        protected override Microsoft.Practices.Prism.Logging.ILoggerFacade CreateLogger()
        {
            return new XLogger();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();


            //Application.Current.MainWindow = (Window)this.Shell;
            //Application.Current.MainWindow.Show();

            Window winLM = this.Container.GetExportedValue<Shell>("LM");
            winLM.Show();
            Window winRM = this.Container.GetExportedValue<Shell>("RM");
            winRM.Show();
        }

        protected override void InitializeModules()
        {

            base.InitializeModules();
        }


        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override void ConfigureModuleCatalog()
        {
            base.ConfigureModuleCatalog();

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;

            //System.Reflection.Assembly assembly = System.Reflection.Assembly.Load("Xuanyuan.Exam");
            //moduleCatalog.AddModule("XModule", assembly.GetType("Xuanyuan.Exam.XModule").AssemblyQualifiedName);

            //moduleCatalog.AddModule(new ModuleInfo() { ModuleName = "Xuanyuan.Shells" });
            //moduleCatalog.AddModule(typeof(Xuanyuan.Exam.XModule));
            //moduleCatalog.AddModule(typeof(Xuanyuan.Shells.LM));
            
            
        }

        protected override System.ComponentModel.Composition.Hosting.AggregateCatalog CreateAggregateCatalog()
        {
            return base.CreateAggregateCatalog();
        }

        protected override void ConfigureAggregateCatalog()
        {
            System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
            sw.Start();

            //this.AggregateCatalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(typeof(Xuanyuan.Shells.LM).Assembly));
            //this.AggregateCatalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(typeof(Xuanyuan.Exam.XModule).Assembly));


            List<string> assemblyList = new List<string>() { "Xuanyuan.XBoot", "Xuanyuan.Shells", "Xuanyuan.Exam", "Xuanyuan.Reference", "Xuanyuan.ExamVM", "Xuanyuan.ExamM" };
            foreach (var assemblyName in assemblyList)
            {
                System.Reflection.Assembly assembly = System.Reflection.Assembly.Load(assemblyName);
                this.AggregateCatalog.Catalogs.Add(new System.ComponentModel.Composition.Hosting.AssemblyCatalog(assembly));
            }

            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
            
            base.ConfigureAggregateCatalog();
        }


        protected override void ConfigureServiceLocator()
        {
            IServiceLocator serviceLocator = this.Container.GetExportedValue<IServiceLocator>();
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
        }

        protected override System.Windows.DependencyObject CreateShell()
        {
            return new Shell();
        }


        public override void Run(bool runWithDefaultConfiguration)
        {
            

            base.Run(runWithDefaultConfiguration);

        }
    }
}
