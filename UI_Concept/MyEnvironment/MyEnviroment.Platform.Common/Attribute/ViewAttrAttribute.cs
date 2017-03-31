using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Windows;

namespace MyEnviroment.Platform.Common
{
    public interface IViewMetaData
    {
        string ViewName { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
    public class ViewAttrAttribute : ExportAttribute , IViewMetaData
    {
        public ViewAttrAttribute(string contractName)
            : base(contractName, typeof(FrameworkElement))
        {
            
        }

        #region Implementation of IViewMetaData

        public string ViewName { get;  set; }

        #endregion
    }
}
