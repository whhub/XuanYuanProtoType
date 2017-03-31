using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;

namespace MyEnviroment.Platform.Common
{
    public interface IModelMetaData
    {
        string ModelName { get; }
    }

    [MetadataAttribute]
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
   public class ModelAttrAttribute : ExportAttribute,IModelMetaData
    {
        public ModelAttrAttribute(string contractName,Type contractType)
            :base(contractName,contractType)
        {
            
        }

        #region Implementation of IModelMetaData

        public string ModelName { get;  set; }

        #endregion
    }
}
