/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/28/2016 2:34:30 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/28/2016 2:34:30 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUIDemo.Framework
{
    public interface ICommunication
    {
        string ClientName { get; }

        void Reigster(uint pid, string proxy, string clientName);

        void Reigster<T>();

        void Send(string clientName, object data);

        void Send<T>(T data);

        void Receive(object data);

        event Action<object> DataReceived;
    }
}
