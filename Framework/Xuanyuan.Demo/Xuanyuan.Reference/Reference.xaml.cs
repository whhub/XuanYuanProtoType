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
using System.ComponentModel.Composition;
using Xuanyuan.Core;

namespace Xuanyuan.Reference
{
    /// <summary>
    /// Interaction logic for Reference.xaml
    /// </summary>
    [Export]
    public partial class Reference : UserControl
    {

        [Import]
        public IMessager Messager { get; set; }

        public Reference()
        {
            InitializeComponent();



            this.Loaded += new RoutedEventHandler(Reference_Loaded);
        }

        void Reference_Loaded(object sender, RoutedEventArgs e)
        {
            Messager.Register(100, MessageHandle);
        }

        object MessageHandle(object msg)
        {
            this.Dispatcher.Invoke(new Action(() =>
                {
                    txtMsg.Text = msg.ToString();
                }));


            return null;
        }
    }
}
