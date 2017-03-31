using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xuanyuan.Interface;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Management;
using Xuanyuan.Core;

namespace Xuanyuan.ExamM
{

    [Export(typeof(IExamFunction))]
    public class ExamModel : IExamFunction
    {
        [Import]
        public ILogger Logger { get; set; }

        [Import]
        public IMessager Messager { get; set; }

        Task _task;

        CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        PerformanceCounter pcCpuLoad;
        PerformanceCounter msSubmit;
        PerformanceCounter netDatagrams;

        public ExamModel()
        {
            _task = new Task(MainFunction, cancelTokenSource.Token);
             pcCpuLoad= new PerformanceCounter("Processor", "% Processor Time", "_Total");
            pcCpuLoad.MachineName = ".";
            pcCpuLoad.NextValue();

            msSubmit = new PerformanceCounter("Memory", "% Committed Bytes In Use", "");
            msSubmit.MachineName = ".";
            msSubmit.NextValue();

            netDatagrams = new PerformanceCounter("IPv4", "Datagrams/sec", "");
            netDatagrams.MachineName = ".";
            netDatagrams.NextValue();

           
        }


        public void Start()
        {
            _task.Start();
        }

        public void Stop()
        {
            cancelTokenSource.Cancel();
        }


        private void MainFunction()
        {
            while (!cancelTokenSource.IsCancellationRequested)
            {
                Logger.Log("MainFunction");

                PerformanceInfo pInfo = new PerformanceInfo();

                pInfo.ProcessorTime = pcCpuLoad.NextValue();

                pInfo.MemoryWorkingSet = (long)msSubmit.NextValue();

                pInfo.NetDatagrams = netDatagrams.NextValue();

                ManagementClass mos = new ManagementClass("Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.GetInstances())
                {
                    //if (mo["TotalPhysicalMemory"] != null)
                    {
                        //pInfo.TotalPhysicalMemory = long.Parse(mo["TotalPhysicalMemory"].ToString());
                    }

                    if (mo["FreePhysicalMemory"] != null)
                    {
                        pInfo.FreePhysicalMemory = long.Parse(mo["FreePhysicalMemory"].ToString());
                    }
                }
                RaiseExamFunctionUpdated(pInfo);


                Thread.Sleep(1000);
            }
        }

        private void RaiseExamFunctionUpdated(PerformanceInfo pInfo)
        {
            if (ExamFunctionUpdated != null)
                ExamFunctionUpdated(pInfo);

            Messager.Send(100, pInfo.ProcessorTime.ToString());
        }


        public event Action<PerformanceInfo> ExamFunctionUpdated;
    }

}
