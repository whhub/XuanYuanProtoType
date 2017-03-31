/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/15/2016 9:48:58 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/15/2016 9:48:58 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace MyUIDemo.Config
{
    [Serializable]
    public class UIWindow
    {
        public string WindowName { get; set; }

        public UIWindow()
        {
            RowCllection = new List<RowDefinition>();
            ColumnCllection = new List<ColumnDefinition>();
            ComponentCllection = new List<UIComponent>();
        }

        public List<RowDefinition> RowCllection { get; set; }

        public List<ColumnDefinition> ColumnCllection { get; set; }

        public List<UIComponent> ComponentCllection { get; set; }

        public int Top { get; set; }

        public int Left { get; set; }

        public int Width { get; set; }

        public int Height { get; set; }

        public bool IsShow { get; set; }
    }
}
