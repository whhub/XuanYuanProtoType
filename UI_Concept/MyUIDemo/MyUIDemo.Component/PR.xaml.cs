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
using MyUIDemo.Communication;

namespace MyUIDemo.Component
{
    /// <summary>
    /// Interaction logic for PR.xaml
    /// </summary>
    public partial class PR : UserControl
    {
        private MyCommunication Communication;

        public PR()
        {
            InitializeComponent();

            Communication = new MyCommunication("PR", null);
            Communication.DataReceived += new Action<object>(Communication_DataReceived);
            Communication.Reigster<MessengerData>();
        }

        void Communication_DataReceived(object obj)
        {
            if (obj is MessengerData)
                txtContent.Text = ((MessengerData)obj).Content;
            else
                txtContent.Text = obj.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Communication.Send("PA", "Patient register done! " + DateTime.Now.ToString("HH:mm:ss.fff"));
        }


    }
}
