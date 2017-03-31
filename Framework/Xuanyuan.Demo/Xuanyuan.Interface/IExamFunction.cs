using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Xuanyuan.Interface
{
    public interface IExamFunction
    {
        void Start();

        void Stop();

        event Action<PerformanceInfo> ExamFunctionUpdated;
    }
}
