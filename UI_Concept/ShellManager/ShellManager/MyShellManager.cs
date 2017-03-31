/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/17/2017 9:31:44 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/17/2017 9:31:44 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ShellManager.Interface;

namespace ShellManager
{
    public class MyShellManager : IShellManager
    {
        public MyShellManager()
        {
            ShellCollection = new Dictionary<string, IShell>();
        }

        public IDictionary<string, IShell> ShellCollection { get; set; }

        public bool RegisterShell(IShell shell)
        {
            if (!ShellCollection.Keys.Contains(shell.ShellName))
            {
                ShellCollection.Add(shell.ShellName, shell);
                Console.WriteLine("Shell has been added.");
                PrintShells();
                return true;
            }
            else
            {
                Console.WriteLine("Shell has been exsit.");
            }

            return false;
        }

        public bool UnregisterShell(IShell shell)
        {
            if (ShellCollection.Keys.Contains(shell.ShellName))
            {
                ShellCollection.Remove(shell.ShellName);
                Console.WriteLine("Shell has been removed.");
                PrintShells();
                return true;
            }
            else
            {
                Console.WriteLine("Shell has not been found.");
            }

            return true;
        }

        public IShell GetShell(string shellname)
        {
            if (ShellCollection.Keys.Contains(shellname))
            {
                return ShellCollection[shellname];
            }
            else
            {
                Console.WriteLine("Shell has not been found.");
            }
            return null;
        }

        private void PrintShells()
        {
            string content = "Shells:\t";

            foreach (var shell in ShellCollection)
                content += string.Format("\t[{0}]", shell.Key);

            Console.WriteLine(content);
            Console.WriteLine();
        }
    }
}
