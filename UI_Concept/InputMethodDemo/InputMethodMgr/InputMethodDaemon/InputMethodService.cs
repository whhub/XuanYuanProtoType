using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO.Pipes;
using System.IO;

namespace InputMethodDaemon
{
    /// <summary>
    /// An InputMethodService instance can listen input method 
    /// of each application which enabled the InputMethodInterceptor.
    /// </summary>
    class InputMethodService
    {
        public InputMethodService(InputMethodServiceLog log = null)
        {
            if (log == null) _log = new InputMethodServiceLog();
        }

        public void Start()
        {
            _stopService = false;
            RunForwardInputContextServiceAsync();
            RunForwardKeyEventServiceAsync();
        }

        public void Stop()
        {
            _stopService = true;
        }

        const int PORT = 9091;

        const String PIPENAME = "InputMethodPipe";

        [DllImport("USER32.DLL")]
        static extern void keybd_event(byte bVk, byte bScan, int dwFlags, int dwExtraInfo);

        List<TcpClient> _clients = new List<TcpClient>();

        volatile bool _stopService = false;

        InputMethodServiceLog _log;

        string Context2String(InputMethodContext context)
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

        void DoForwardKeyEventService(TcpClient vkdbClient)
        {
            if (vkdbClient == null) throw new ArgumentNullException("vkdbClient");
            try
            {
                NetworkStream stream = vkdbClient.GetStream();
                while (!_stopService)
                {
                    int key = stream.ReadByte();
                    if (key == -1) return;
                    int flag = stream.ReadByte();
                    if (flag == -1) return;
                    keybd_event((byte)key, 0, flag, 0);
                    if (flag == 0) Console.WriteLine("KeyDown: " + (char)key);
                    else Console.WriteLine("KeyUp: " + (char)key);
                }
            }catch(Exception ex)
            {
                _log.Log("Error", ex.Message);
            }
            vkdbClient.Close();
            _clients.Remove(vkdbClient);
            _log.Log("Trace", "End connection to " + vkdbClient.Client.RemoteEndPoint);
        }

        void DoForwardKeyEventServiceAsync(TcpClient vkdbClient)
        {
            Thread thread = new Thread((obj) => DoForwardKeyEventService(obj as TcpClient));
            thread.Start(vkdbClient);
        }

        void RunForwardKeyEventService()
        {
            TcpListener listener = null;
            try
            {
                listener = new TcpListener(IPAddress.Any, PORT);
                listener.Start();
                _log.Log("Trace", "Start TcpListener on " + PORT);
            }
            catch (Exception ex)
            {
                _log.Log("Error", "Fail to listen port " + PORT);
                _log.Log("Exception", ex.Message);
                listener.Stop();
                return;
            }
            while (!_stopService)
            {
                TcpClient client = listener.AcceptTcpClient();
                lock (_clients)
                {
                    _clients.Add(client);
                }
                _log.Log("Trace", "Begin connection to " + client.Client.RemoteEndPoint);
                DoForwardKeyEventServiceAsync(client);
            }
            listener.Stop();
            _log.Log("Trace", "Stop TcpListener on " + PORT);
        }

        void RunForwardKeyEventServiceAsync()
        {
            Thread thread = new Thread(RunForwardKeyEventService);
            thread.Start();
        }

        void RunForwardInputContextService()
        {
            NamedPipeServerStream pipe = null;
            BinaryReader binReader = null;
            try
            {
                pipe = new NamedPipeServerStream(PIPENAME, PipeDirection.In);
                binReader = new BinaryReader(pipe);
                _log.Log("Trace", "Success to create " + PIPENAME);
            }
            catch (Exception ex)
            {
                _log.Log("Error", string.Format("Fail to create {0}", PIPENAME));
                _log.Log("Error", ex.Message);
                pipe.Close();
                _stopService = true;
            }
            _log.Log("Trace", "Begin RunForwardInputContextService");
            while (!_stopService)
            {
                try
                {
                    if (!pipe.IsConnected)
                    {
                        _log.Log("Trace", "Pipe Waiting");
                        pipe.WaitForConnection();
                        _log.Log("Trace", "Pipe Connect");
                    }
                    int nbytesToRead = binReader.ReadInt32();
                    if (nbytesToRead == 0)
                    {
                        pipe.Disconnect();
                        _log.Log("Trace", "Pipe Disconnet");
                        continue;
                    }
                    byte[] buf = new byte[nbytesToRead];
                    int nbytesReaded = pipe.Read(buf, 0, nbytesToRead);
                    if (nbytesReaded != nbytesToRead)
                    {
                        pipe.Disconnect();
                        continue;
                    }
                    InputMethodContext context = InputMethodContext.ParseFrom(buf);
                    string strContext = Context2String(context);
                    Console.WriteLine(strContext);
                    lock (_clients)
                    {
                        foreach (TcpClient client in _clients)
                        {
                            if (client.Connected && client.GetStream().CanWrite)
                            {
                                new BinaryWriter(client.GetStream()).Write(buf.Length);
                                client.GetStream().Write(buf, 0, buf.Length);
                                _log.Log("Trace", "Forward InputMethodContext to " + client.Client.RemoteEndPoint);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _log.Log("Error", ex.Message);
                    _log.Log("Error", ex.Source);
                    _log.Log("Error", ex.StackTrace);
                }
            }
            pipe.Close();
            _log.Log("Trace", "End RunForwardInputContextService");
        }

        void RunForwardInputContextServiceAsync()
        {
            Thread thread = new Thread(RunForwardInputContextService);
            thread.Start();
        }
    }
}
