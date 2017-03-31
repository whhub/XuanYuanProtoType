using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIH.Mcsf.Core;
using System.Net;
using System.Net.Sockets;

namespace ShellManager.Core
{
    public class CommunicationHelper
    {

        public static CLRCommunicationProxy InitCommunication(string proxyName, int port)
        {
            CLRCommunicationProxy proxy = null;
            try
            {
                IPAddress[] ipList = Dns.GetHostAddresses(Dns.GetHostName());
                IPAddress ip = ipList.First((ipObject) => { return ipObject.AddressFamily == AddressFamily.InterNetwork; });

                string ipaddress = "127.0.0.1:10000";
                string listenaddress = "127.0.0.1" + ":" + port;

                proxy = new CLRCommunicationProxy();
                proxy.SetName(proxyName);
                //连接到SystemDispatcher
                int i = proxy.CheckCastToSystemDispatcher(ipaddress);
                proxy.StartListener(listenaddress);


                Console.WriteLine(proxyName + " Init Success!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(proxyName + " Init Faild:");
                Console.WriteLine(ex.Message);
            }

            return proxy;
        }


        #region SendCommand

        /// <summary>
        /// 
        /// </summary>
        public static void SendAsyncCommand(CLRCommunicationProxy proxy, int commandID, string receiver, string description = "")
        {
            try
            {

                var context = new CommandContext();
                context.iCommandId = commandID;
                context.sReceiver = receiver;
                //context.sStringObject = buffer; 

                var result = proxy.AsyncSendCommand(context);
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public static string SendCommandString(CLRCommunicationProxy proxy, int commandID, string receiver, string buffer, string description = "")
        {
            try
            {

                var context = new CommandContext();
                context.iCommandId = commandID;
                context.sReceiver = receiver;
                //context.sStringObject = buffer; 
                context.sSerializeObject = Encoding.UTF8.GetBytes(buffer);
                var result = proxy.SyncSendCommand(context);

                return result.GetSerializedString();
            }
            catch (Exception ex)
            {
                //this.Dispatcher.BeginInvoke(new Action<string>(InsertLog), ex.Message);
            }

            return String.Empty;
        }



        #endregion
    }
}
