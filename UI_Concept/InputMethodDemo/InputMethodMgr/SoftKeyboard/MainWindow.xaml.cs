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
using System.Collections.Concurrent;
using System.Net.Sockets;
using System.Net;
using System.IO;
using System.Threading;

namespace SoftKeyboard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Queue<byte> _keys;
        
        TcpClient _tcpClient;
        IPEndPoint _ipEndPoint = new IPEndPoint(IPAddress.Parse("10.8.94.5"),9091);
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = e.OriginalSource as TextBlock;
            if (textBlock != null)
            {
                String text = textBlock.Text;
                Send(GetKey(text), 0);
            }
        }

        private byte GetKey(string text)
        {
            if (text.Length == 1)
            {
                char ch = text.First();
                return (byte)ch;
            }
            else if (text == "SPACE")
            {
                return 32;
            }
            else if (text == "DEL")
            {
                return 127;
            }
            else return 0;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = e.OriginalSource as TextBlock;
            if (textBlock != null)
            {
                String text = textBlock.Text;
                Send(GetKey(text), 0x02);
            }
        }

        private void Send(byte key, byte flag)
        {
            if (TryConnect())
            {
                NetworkStream stream = _tcpClient.GetStream();
                stream.WriteByte(key);
                stream.WriteByte(flag);
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            _tcpClient = new TcpClient();
            Action task = () =>
            {
                ReceiveInputMethodContext();
            };
            task.BeginInvoke(null, null);
        }

        private void Window_Unloaded(object sender, RoutedEventArgs e)
        {
            if (_tcpClient.Connected)
            {
                _tcpClient.Close();
            }
        }

        private bool TryConnect()
        {
            if (_tcpClient.Connected) return true;
            try
            {
                _tcpClient.Connect(_ipEndPoint);
            }
            catch (SocketException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _tcpClient.Connected;
        }

        private void ReceiveInputMethodContext()
        {
            while (true)
            {
                if (_tcpClient.Connected)
                {
                    NetworkStream stream = _tcpClient.GetStream();
                    BinaryReader binReader = new BinaryReader(stream);
                    int size = binReader.ReadInt32();
                    if (size <= 0)
                    {
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Candidates.Text = "";
                        }));
                    }
                    else
                    {
                        byte[] bytes = new byte[size];
                        stream.Read(bytes, 0, size);
                        InputMethodContext context = InputMethodContext.ParseFrom(bytes);
                        Application.Current.Dispatcher.BeginInvoke(new Action(() =>
                        {
                            Candidates.Text = ParseContext(context);
                        }));
                    }
                }
                else
                {
                    if (!TryConnect()) Thread.Sleep(1000);
                }
            }
        }

        static string ParseContext(InputMethodContext context)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < context.CandidatesCount; i++)
            {
                sb.Append(i + 1);
                sb.Append("\t");
            }
            sb.Append("\r\n");
            for (int i = 0; i < context.CandidatesCount; i++)
            {
                sb.Append(context.GetCandidates(i));
                sb.Append("\t");
            }
            sb.Append("\r\n");
            sb.Append("PAGE : " + context.PageIndex);
            return sb.ToString();
        }
    }
}
