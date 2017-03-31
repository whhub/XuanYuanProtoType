/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/15/2016 9:50:19 AM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/15/2016 9:50:19 AM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;

namespace MyUIDemo.Config
{
   public class UIConfig
    {
       public static UIProcesser Test()
       {

           UIProcesser p = new UIProcesser() { ProcesserName="MainProcesser"};
           p.Windows = new List<UIWindow>();

           UIWindow winLM = new UIWindow() { WindowName="LM"};
           winLM.Top = winLM.Left = 0;
           winLM.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2;
           winLM.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
           winLM.ColumnCllection.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
           winLM.ColumnCllection.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
           winLM.RowCllection.Add(new RowDefinition());
           winLM.RowCllection.Add(new RowDefinition() { Height = new GridLength(100) });
           winLM.ComponentCllection.Add(new UIComponent() { ClassName = "Examination" });
           winLM.ComponentCllection.Add(new UIComponent() { ClassName = "MedViewer", GridColume = 1 });
           winLM.ComponentCllection.Add(new UIComponent() { ClassName = "StatusBar", GridRow = 1, GridColumeSpan = 2 });
           winLM.IsShow = true;
           p.Windows.Add(winLM);

           UIWindow winRM = new UIWindow() { WindowName = "RM" };
           winRM.Top = 0;
           winRM.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2;
           winRM.Width = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width/2;
           winRM.Height = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height;
           winRM.ColumnCllection.Add(new ColumnDefinition() { Width = new GridLength(3, GridUnitType.Star) });
           winRM.ColumnCllection.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
           winRM.ComponentCllection.Add(new UIComponent() { ClassName = "MedViewer", GridColume = 0 });
           winRM.ComponentCllection.Add(new UIComponent() { ClassName = "Parameter", GridColume = 1 });
           winRM.IsShow = true;
           p.Windows.Add(winRM);


           UIWindow winPA = new UIWindow() { WindowName = "PA" };
           winPA.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2 - 150;
           winPA.Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2 - 150;
           winPA.Width = 300;
           winPA.Height = 300;
           winPA.ComponentCllection.Add(new UIComponent() { ClassName = "PA", GridColume = 0 });
           p.Windows.Add(winPA);

           UIWindow winPR = new UIWindow() { WindowName = "PR" };
           winPR.Left = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Width / 2 - 150;
           winPR.Top = System.Windows.Forms.Screen.PrimaryScreen.WorkingArea.Height / 2 - 150;
           winPR.Width = 300;
           winPR.Height = 300;
           winPR.ComponentCllection.Add(new UIComponent() { ClassName = "PR", GridColume = 0 });
           p.Windows.Add(winPA);

           //SerializerHelper.SerializerToFile(p, @"D:\UIConfig.xml");

           return p;
       }



    }
}
