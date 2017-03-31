using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShellManager.Interface;
using UIH.Mcsf.Core;

namespace ShellManager.Core
{
    public class MyCommunicator : ICommunicator
    {
        CLRCommunicationProxy Proxy { get; set; }

        public string ProxyName { get { return Proxy.GetName(); } }

        public MyCommunicator(string name, int port)
        {
            Proxy = CommunicationHelper.InitCommunication(name, port);
            Proxy.RegisterCommandHandler(ShellParam.ShellManagerCommandID, new MyCommandHandler(CommandHandle));
        }


        public string Send(string target,string messageType, string message)
        {
            CommandContext context = new CommandContext();
            context.iCommandId = ShellParam.ShellManagerCommandID;
            context.sReceiver = target;
            context.sSender = Proxy.GetName();
            context.sStringObject = messageType + ":" + message;
            ISyncResult result = Proxy.SyncSendCommand(context);

            return result.GetSerializedString();
        }

        public event Action<string, string, string> MessageReceived;

        private void CommandHandle(string sender,string messageType, string message)
        {
            if (MessageReceived != null)
                MessageReceived(sender, messageType, message);
        }

    }
}
