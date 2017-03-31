/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/24/2016 7:31:43 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/24/2016 7:31:43 PM</updatedate>
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
    public class MyCommunication : ICommunication
    {
        private uint _pid;

        private string _name;

        public string ClientName
        {
            get { return _name; }
        }

        ICommunicationProxy _proxy;

        public MyCommunication(string name, ICommunicationProxy proxy)
        {
            _pid = 0;
            _name = name;
            _proxy = proxy;

            if (NamedRouter==null)
            NamedRouter = new List<NamedRouterItem>();
            if (DataRouter == null)
            DataRouter = new List<DataRouterItem>();

            Reigster(_pid, "", name);
        }


        #region Route by target name

        static List<NamedRouterItem> NamedRouter { get; set; }

        public void Reigster(uint pid, string proxy, string clientName)
        {
            NamedRouter.Add(new NamedRouterItem() { PID = pid, ProxyName = proxy, ClientName = clientName });
            MyMessengerEx.Default.Register(this);
        }

        #endregion



        #region Route by target data

        static List<DataRouterItem> DataRouter { get; set; }

        public void Reigster<T>()
        {
            DataRouter.Add(new DataRouterItem() { PID = _pid, ProxyName = "", ClientName = _name, DataType = typeof(T).FullName });
        }

        #endregion



        #region Netbase

        public void SendCommand()
        {

        }

        #endregion


        public void Send(string clientName, object data)
        {
            var routerList = NamedRouter.FindAll((r) => { return r.ClientName == clientName; });
            foreach (var router in routerList)
            {
                MyMessengerEx.Default.Send(router.ClientName, data);
            }
        }

        public void Send<T>(T data)
        {
            var routerList = DataRouter.FindAll((r) => { return r.DataType == typeof(T).FullName; });
            foreach (var router in routerList)
            {
                MyMessengerEx.Default.Send(router.ClientName, data);
            }
        }


        public void Receive(object data)
        {
            if (DataReceived != null)
                DataReceived(data);
        }

        public event Action<object> DataReceived;





    }

    [Serializable]
    public class NamedRouterItem
    {
        public uint PID { get; set; }

        public string ProxyName { get; set; }

        public string ClientName { get; set; }
    }

    [Serializable]
    public class DataRouterItem
    {
        public uint PID { get; set; }

        public string ProxyName { get; set; }

        public string ClientName { get; set; }

        public string DataType { get; set; }
    }

}
