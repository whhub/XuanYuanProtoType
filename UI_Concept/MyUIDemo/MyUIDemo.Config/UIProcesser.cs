using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUIDemo.Config
{
    [Serializable]
    public class UIProcesser
    {
        public List<UIWindow> Windows { get; set; }

        public string ProcesserName { get; set; }
    }
}
