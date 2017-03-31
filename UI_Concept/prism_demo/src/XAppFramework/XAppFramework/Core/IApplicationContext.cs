using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XAppFramework.Core
{
    public interface IApplicationContext
    {
        IDictionary<string, object> Attributes { get; }
    }
}
