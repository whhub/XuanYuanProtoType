using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Pipes;
using System.IO;
using System.Threading;

namespace InputMethodDaemon
{
    class Program
    {
        const int WAITING_START_TIME = 1000;//ms
        const int WAITING_STOP_TIME = 1000;
        static void Main(string[] args)
        {
            InputMethodService service = new InputMethodService();
            service.Start();
            Thread.Sleep(WAITING_START_TIME);
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd.ToLower() == "stop")
                {
                    service.Stop();
                    break;
                }
            }
            Thread.Sleep(WAITING_START_TIME);
        }
    }
}
