/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/29/2016 11:35:37 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/29/2016 11:35:37 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MyUIDemo.Framework;

namespace MyUIDemo.Communication
{
    public class MyMessengerEx
    {

        private static MyMessengerEx _instance;
        private MyMessengerEx()
        {
            CommunicationCollection = new List<ICommunication>();
        }

        public static MyMessengerEx Default
        {
            get
            {
                if (_instance == null)
                    _instance = new MyMessengerEx();
                return _instance;
            }
        }



        private List<ICommunication> CommunicationCollection { get; set; }

        public void Register(ICommunication communication)
        {
            CommunicationCollection.Add(communication);
        }

        public void Send(string name, object data)
        {
            var targetList= CommunicationCollection.FindAll((c) => { return c.ClientName == name; });
            foreach (var target in targetList)
            {
                target.Receive(data);
            }

        }
    }
}
