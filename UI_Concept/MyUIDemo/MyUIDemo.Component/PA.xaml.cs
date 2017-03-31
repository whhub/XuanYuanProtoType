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
    /// Interaction logic for PA.xaml
    /// </summary>
    public partial class PA : UserControl
    {
        private MyCommunication Communication;

        public PA()
        {
            InitializeComponent();

            Communication = new MyCommunication("PA", null);
            Communication.DataReceived += new Action<object>(Communication_DataReceived);
        }

        void Communication_DataReceived(object obj)
        {
            txtContent.Text = obj.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Communication.Send("PR", "Patient Information! " + DateTime.Now.ToString("HH:mm:ss.fff"));
            MessengerData data=new MessengerData("Patient Information! " + DateTime.Now.ToString("HH:mm:ss.fff"));
            Communication.Send<MessengerData>(data);
        }

    }
}
