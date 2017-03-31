using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIH.Mcsf.Core;
using System.Threading.Tasks;


namespace ShellManager.Core
{
    public class MyCommandHandler : ICLRCommandHandler
    {
        private Action<string,string,string> _action;

        public MyCommandHandler(Action<string, string, string> action)
        {
            _action = action;
        }

        /// <summary>
        /// Analyse status value from UprotocolMsg
        /// </summary>
        /// <param name="context"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override int HandleCommand(CommandContext context, ISyncResult result)
        {
            try
            {
                string msg = context.sStringObject;
                string[] msgs = msg.Split(':');

                if (_action != null)
                    _action(context.sSender, msgs[0], msgs[1]);
                result.SetSerializedString("OK");
                return 0;
            }
            catch (Exception ex)
            {
                return -1;
            }


        }
    }

    
}
