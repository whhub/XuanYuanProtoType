/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/24/2016 7:37:20 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/24/2016 7:37:20 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUIDemo.Communication
{ 
    public class MessengerData
    {

        public MessengerData(string content)
        {
            Content = content;
        }

        public string Content
        {
            get;
            set;
        }


    }
}
