using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShellManager.Core;
using ShellManager.Interface;

namespace ShellManager
{
    class Program
    {
        static MyShellManager shellManager;

        static MyCommunicator MyProxy;

        static void Main(string[] args)
        {

            shellManager = new MyShellManager();

            MyProxy = new MyCommunicator(ShellParam.ShellServerProxyName, ShellParam.ShellServerProxyPort);
            MyProxy.MessageReceived += new Action<string, string, string>(Communicator_MessageReceived);


            while (true)
            {
                string input = Console.ReadLine();
                if (input.ToUpper() == "Q")
                    break;
                else
                {
                    string[] argList = input.Split(' ');
                    string command = argList[0];
                    if (argList.Length >= 2)
                    {
                        for (int i = 1; i < argList.Length; i++)
                            ChangeShell(command, argList[i]);
                    }
                }
            }
        }

        private static void ChangeShell(string command, string name)
        {
            IShell shell = shellManager.GetShell(name);
            if (command.ToUpper() == "S")
            {
                if (shell != null)
                    shell.ShowShell();
            }
            else if (command.ToUpper() == "H")
            {
                if (shell != null)
                    shell.HideShell();
            }
        }


        private static void Communicator_MessageReceived(string sender, string messageType, string message)
        {
            if (!string.IsNullOrWhiteSpace(sender) & !string.IsNullOrWhiteSpace(messageType) & !string.IsNullOrWhiteSpace(message))
            {
                MyShellProxy shell = new MyShellProxy(MyProxy, sender, message);
                if (messageType.Equals(ShellParam.MessageType.RegisterShell))
                {
                    shellManager.RegisterShell(shell);
                }
                else if (messageType.Equals(ShellParam.MessageType.UnregisterShell))
                {
                    shellManager.UnregisterShell(shell);
                }
            }
        }
    }
}
