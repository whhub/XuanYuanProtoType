/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>3/9/2017 11:15:57 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>3/9/2017 11:15:57 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xuanyuan.Core;
using System.ComponentModel.Composition;

namespace Xuanyuan.XBoot
{
    [Export(typeof(IMessager))]
    [PartCreationPolicy(CreationPolicy.NonShared)]
    public class XMessager : IMessager
    {
        public object Send(int id, object msg)
        {

            if (MyXMessager.Instance.TransferList.ContainsKey(id))
            {
                var func = MyXMessager.Instance.TransferList[id];

                return func(msg);
            }

            return null;
        }


        public void Register(int id, Func<object, object> func)
        {
            MyXMessager.Instance.TransferList.Add(id, func);
        }
    }

    internal class MyXMessager
    {

        private static MyXMessager _instance = new MyXMessager();
        public static MyXMessager Instance
        {
            get { return _instance; }
        }

        Dictionary<int, Func<object, object>> _transferList = new Dictionary<int, Func<object, object>>();
        public Dictionary<int, Func<object, object>> TransferList
        {
            get { return _transferList; }
            set { _transferList = value; }
        }

    }
}
