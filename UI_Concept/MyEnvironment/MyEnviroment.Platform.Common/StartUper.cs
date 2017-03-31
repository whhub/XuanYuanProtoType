using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Text;
using System.Windows;
using GalaSoft.MvvmLight;

namespace MyEnviroment.Platform.Common
{
    public class StartUper<T>
        where T : Window,new()
    {
        private CompositionContainer _container = null;

        public T Window { get; private set; }

        public StartUper()
        {
            //first, create catalog and container
            var aggregateCatalog = new AggregateCatalog();
            var directoryCataLog = new DirectoryCatalog(Environment.CurrentDirectory);
            aggregateCatalog.Catalogs.Add(directoryCataLog);
            this. _container = new CompositionContainer(aggregateCatalog);
           // this._container.ComposeParts();

            //second , initialize IoC 
            IoC.GetInstance = this.GetInstance;

            this.Window = new T();
        }

        public object GetInstance(Type type, string key)
        {
            string contract = string.IsNullOrEmpty(key) ? AttributedModelServices.GetContractName(type) : key;
            var export = this._container.GetExportedValue<object>(contract);
            return export;
        }

    }
}
