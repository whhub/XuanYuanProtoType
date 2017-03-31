using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace MyEnviroment.Platform.Common
{
    public interface IViewModelMetaData
    {
        string ViewModelName { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class ViewModelAttrAttribute : ExportAttribute, IViewModelMetaData
    {
        public ViewModelAttrAttribute(string contractName)
            : base(contractName, typeof(ViewModelBase))
        {

        }

        #region Implementation of IViewModelMetaData

        public string ViewModelName { get; set; }

        #endregion
    }
}
