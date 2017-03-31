/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/7/2017 4:44:18 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/7/2017 4:44:18 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.ViewModel;
using System.ComponentModel.Composition;
using System.Collections.ObjectModel;
using Xuanyuan.Interface;

namespace Xuanyuan.ExamVM
{

    [Export("ExamViewModel", typeof(NotificationObject))]
    public class ExamViewModel : NotificationObject
    {


        private string _patientName;
        public string PatientName
        {
            get { return _patientName; }
            set
            {
                _patientName = value;
                RaisePropertyChanged(() => PatientName);
            }
        }


        private ExamParameter _parameter1;
        public ExamParameter Parameter1
        {
            get { return _parameter1; }
            set
            {
                _parameter1 = value;
                RaisePropertyChanged(() => Parameter1);
            }
        }


        private ExamParameter _parameter2;
        public ExamParameter Parameter2
        {
            get { return _parameter2; }
            set
            {
                _parameter2 = value;
                RaisePropertyChanged(() => Parameter2);
            }
        }


        private ExamParameter _parameter3;
        public ExamParameter Parameter3
        {
            get { return _parameter3; }
            set
            {
                _parameter3 = value;
                RaisePropertyChanged(() => Parameter3);
            }
        }

        private ExamParameter _parameter4;
        public ExamParameter Parameter4
        {
            get { return _parameter4; }
            set
            {
                _parameter4 = value;
                RaisePropertyChanged(() => Parameter4);
            }
        }


        public ExamViewModel()
        {
            //PatientName = "VIP";

            Parameter1 = new ExamParameter() { ParameterName = "CPU占用", ParameterValue = "" };
            Parameter2 = new ExamParameter() { ParameterName = "网络流量", ParameterValue = "" };
            Parameter3 = new ExamParameter() { ParameterName = "内存可用数", ParameterValue = "" };
            Parameter4 = new ExamParameter() { ParameterName = "Frame rate", ParameterValue = "" };
        }

        [Import(typeof(IExamFunction))]
        public IExamFunction ExamImpl
        {
            get { return _examImpl; }
            set
            {
                _examImpl = value;
                if (_examImpl != null)
                {
                    _examImpl.ExamFunctionUpdated += new Action<PerformanceInfo>(ExamImpl_Updated);
                    _examImpl.Start();
                }
            }
        }

        void ExamImpl_Updated(PerformanceInfo obj)
        {
            Parameter1.ParameterValue = string.Format("{0:N0} %", obj.ProcessorTime);
            Parameter2.ParameterValue = string.Format("{0:N0} Kb", obj.NetDatagrams);
            Parameter3.ParameterValue = string.Format("{0:N0} Mb", obj.FreePhysicalMemory / 1024);
        }
        private IExamFunction _examImpl;


    }


    public class ExamParameter : NotificationObject
    {
        private string _parameterName;
        public string ParameterName
        {
            get { return _parameterName; }
            set
            {
                _parameterName = value;
                RaisePropertyChanged(() => ParameterName);
            }
        }

        private string _parameterValue;
        public string ParameterValue
        {
            get { return _parameterValue; }
            set
            {
                _parameterValue = value;
                RaisePropertyChanged(() => ParameterValue);
            }
        }
    }
}
