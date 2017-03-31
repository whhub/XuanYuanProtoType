using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.MefExtensions;
using System.Windows;
using Microsoft.Practices.Prism.Modularity;
using System.ComponentModel.Composition.Hosting;
using System.Xml;
using System.IO;
using Microsoft.Practices.Prism.Logging;
using System.ComponentModel.Composition;
using XAppFramework.Common;
using XAppFramework.Shared;
using XAppFramework.Core.ViewRegistry;
using Microsoft.Practices.Prism.Regions;
using System.Reflection;
using System.Windows.Controls;

namespace XAppFramework
{
    class AppBootstrapper : MefBootstrapper
    {
        const string XMLNODE_MODULE = "module";

        const string XMLATTR_ASSEMBLY = "assembly";

        private string _xmlModuleConfigFilePath;

        private ViewRegistryConfig _viewRegistryConfig;

        protected override DependencyObject CreateShell()
        {
            return this.Container.GetExportedValue<LeftWindow>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            Application.Current.MainWindow = (LeftWindow)this.Shell;
            LeftWindow leftShell = (LeftWindow)this.Shell;
            RightWindow rightShell = this.Container.GetExportedValue<RightWindow>();
            double width = System.Windows.SystemParameters.PrimaryScreenWidth / 2.0;
            double height = System.Windows.SystemParameters.PrimaryScreenHeight;
            leftShell.Width = width;
            leftShell.Height = height;
            leftShell.Left = 0;
            leftShell.Top = 0;
            rightShell.Width = width;
            rightShell.Height = height;
            rightShell.Left = width;
            rightShell.Top = 0;
            leftShell.Show();
            rightShell.Show();
        }

        protected override void ConfigureAggregateCatalog()
        {
            base.ConfigureAggregateCatalog();
            AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(AppBootstrapper).Assembly));
            XmlDocument doc = new XmlDocument();
            doc.Load(_xmlModuleConfigFilePath);
            XmlNodeList nodes = doc.GetElementsByTagName(XMLNODE_MODULE);
            foreach (XmlNode node in nodes)
            {
                XmlAttribute attr_Assembly = node.Attributes[XMLATTR_ASSEMBLY];
                if (attr_Assembly != null)
                {
                    if (File.Exists(attr_Assembly.Value))
                    {
                        Logger.Log(string.Format("add AssemblyCatalog {0}", attr_Assembly.Value), Category.Debug, Priority.Low);
                        var assemblyCatalog = new AssemblyCatalog(attr_Assembly.Value);
                        this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(attr_Assembly.Value));
                    }
                    else
                    {
                        Logger.Log(string.Format("file {0} dose not exist",attr_Assembly.Value), Category.Warn, Priority.High);
                    }
                }
            }
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new ConfigurationModuleCatalog();
        }

        public void ConfigureModuleCatalog(string xmlFilePath)
        {
            _xmlModuleConfigFilePath = xmlFilePath;
        }

        protected override ILoggerFacade CreateLogger()
        {
            return new Logger();
        }

        public void ConfigureViewRegistry(string xmlFilePath)
        {
            ViewRegistryConfigBuilder buidler = new ViewRegistryConfigBuilder();
            _viewRegistryConfig = buidler.BuildFromXmlFile(xmlFilePath);
        }

        public override void Run(bool runWithDefaultConfiguration)
        {
            base.Run(runWithDefaultConfiguration);
            DoViewRegistry();

        }

        void DoViewRegistry()
        {
            var regionMng = Container.GetExport<IRegionManager>().Value;
            foreach (ViewRegistryConfigEntry entry in _viewRegistryConfig.Entries)
            {
                regionMng.RegisterViewWithRegion(entry.Region, () =>
                {
                    try
                    {
                        ViewModelBase dataContext = Container.GetExportedValue<ViewModelBase>(entry.DataContextName);
                        dataContext.Initialize();
                        Logger.Log("Initialize " + dataContext.ToString(),Category.Debug, Priority.Medium);
                        Control view = Container.GetExportedValue<Control>(entry.Name);
                        view.DataContext = dataContext;
                        Logger.Log("Initialize " + view.ToString(), Category.Debug, Priority.Medium);
                        return view;
                    }
                    catch (Exception ex)
                    {
                        Logger.Log(ex.Message, Category.Exception, Priority.High);
                        return null;
                    }
                });
            }
        }
    }
}
