/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/15/2016 9:55:36 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/15/2016 9:55:36 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyUIDemo.Config
{
    [Serializable]
    public class UIComponent
    {
        public string ClassName { get; set; }

        

        public int GridRow { get; set; }
        public int GridRowSpan { get; set; }
        public int GridColume { get; set; }
        public int GridColumeSpan { get; set; }

    }
}
