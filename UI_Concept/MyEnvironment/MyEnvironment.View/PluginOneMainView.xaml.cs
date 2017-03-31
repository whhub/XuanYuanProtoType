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
using MyEnviroment.Platform.Common;

namespace MyEnvironment.View
{
    /// <summary>
    /// Interaction logic for PluginOneMainView.xaml
    /// </summary>
    [ViewAttr("PluginOneMainView", ViewName = "PluginOneMainView")]
    public partial class PluginOneMainView : UserControl
    {
        public PluginOneMainView()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
