/// ------------------------------------------------------------------------------
/// <copyright company="United-Imaging">
/// Copyright (c) 2014 United-Imaging. All rights reserved.
/// </copyright>
/// <author>Yang Bu</author>
/// <date>11/29/2016 1:14:51 PM</date>
/// <updateauthor>Yang Bu</updateauthor>
/// <updatedate>11/29/2016 1:14:51 PM</updatedate>
/// <description>
/// </description>
/// ------------------------------------------------------------------------------


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;
using System.Windows;
using MyUIDemo.Config;
using System.Reflection;
using MyUIDemo.Framework;

namespace MyUIDemo
{
    public class UIConstructor
    {

        List<Window> WindowCollection { get; set; }

        public UIConstructor()
        {
            WindowCollection = new List<Window>();
        }


        public void InitializeUI()
        {
            //UIProcesser p = UIConfig.Test();
            //foreach (UIWindow w in p.Windows)
            //{
            //    Window win = InitWindow(w);
            //    WindowCollection.Add(win);
            //    if (w.IsShow)
            //        win.Show();
            //}




        }




        private Window InitWindow(UIWindow uiWin)
        {
            Grid grid = new Grid();
            foreach (var row in uiWin.RowCllection)
            {
                grid.RowDefinitions.Add(row);
            }
            foreach (var column in uiWin.ColumnCllection)
            {
                grid.ColumnDefinitions.Add(column);
            }


            foreach (var component in uiWin.ComponentCllection)
            {
                Assembly assembly = Assembly.LoadFile(System.Environment.CurrentDirectory + @"\MyUIDemo.Component.exe");
                Assembly assembly1 = Assembly.LoadFile(System.Environment.CurrentDirectory + @"\MyUIDemo.Controls.dll");
                object obj = assembly.CreateInstance("MyUIDemo.Component." + component.ClassName);
                if(obj==null)
                    obj = assembly1.CreateInstance("MyUIDemo.Controls." + component.ClassName);

                List<Type> ts = GetTypesByBase(assembly, typeof(UserControl));

                UserControl element = obj as UserControl;

                if (element != null)
                {
                    grid.Children.Add(element);
                    Grid.SetColumn(element, component.GridColume);
                    Grid.SetRow(element, component.GridRow);

                    if (component.GridColumeSpan > 1)
                        Grid.SetColumnSpan(element, component.GridColumeSpan);

                    if (component.GridRowSpan > 1)
                        Grid.SetColumnSpan(element, component.GridRowSpan);
                }

            }

            Window win = new Window();
            win.Content = grid;
            win.Top = uiWin.Top;
            win.Left = uiWin.Left;
            win.Width = uiWin.Width;
            win.Height = uiWin.Height;
            return win;
        }

        private List<Type> GetTypesByInterface(Assembly assembly, Type interfaceType)
        {
            Type[] types = assembly.GetTypes();

            List<Type> mTypes = new List<Type>();
            foreach (var t in types)
            {
                if (t.GetInterface(interfaceType.FullName) != null)
                    mTypes.Add(t);
            }
            return mTypes;
        }

        private List<Type> GetTypesByBase(Assembly assembly, Type baseType)
        {
            Type[] types = assembly.GetTypes();

            List<Type> mTypes = new List<Type>();
            foreach (var t in types)
            {
                if (IsBaseType(t, baseType))
                    mTypes.Add(t);
            }
            return mTypes;
        }

        private bool IsBaseType(Type source, Type target)
        {
            if (source.BaseType == null)
                return false;
            else
            {
                if (source.BaseType == target)
                    return true;
                else
                    return IsBaseType(source.BaseType, target);
            }
        }

    }
}
