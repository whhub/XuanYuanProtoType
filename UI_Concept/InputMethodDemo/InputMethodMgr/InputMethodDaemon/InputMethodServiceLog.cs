using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InputMethodDaemon
{
    class InputMethodServiceLog
    {
        public virtual void Log(String category, String msg)
        {
            Console.WriteLine("{0} : {1}",category, msg);
        }
    }
}
