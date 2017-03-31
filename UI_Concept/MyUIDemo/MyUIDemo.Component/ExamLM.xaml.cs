using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MyUIDemo.Controls;
using MyUIDemo.Config;
using System.Reflection;

namespace MyUIDemo.Component
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ExamLM : Window
    {
        public ExamLM()
        {
            InitializeComponent();

            InitializeUI();


        }


        private void InitializeUI()
        {
            //mainGrid.RowDefinitions.Add(new RowDefinition() );
            //mainGrid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength(80) });
            //mainGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(120) });
            //mainGrid.ColumnDefinitions.Add(new ColumnDefinition());


            //Examination ctrl = new Examination();
            //mainGrid.Children.Add(ctrl);

            UIProcesser p = UIConfig.Test();

            //foreach (var win in p.Windows)
            //{
            //    Window window = InitWindow(win);
            //    window.Show();
            //}

            Grid g = InitWindow(p.Windows[0]);
            this.Content = g;
        }

        private Grid InitWindow(UIWindow uiWin)
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
                Assembly assembly = Assembly.LoadFile(System.Environment.CurrentDirectory + @"\MyUIDemo.Controls.dll");
                object obj = assembly.CreateInstance("MyUIDemo.Controls." + component.ClassName);

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

            return grid;
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
                if (IsBaseType(t,baseType))
                    mTypes.Add(t);
            }
            return mTypes;
        }

        private bool IsBaseType(Type source,Type target)
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
