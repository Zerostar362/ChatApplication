using ChatApplication.Code.Broker;
using ChatApplication.Code.Broker.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.HandshakePipeline
{
    public class TcpListenerHandler
    {

        private HandshakePipelineDelegate _next;


        private int _port;
        private bool _isRunning;
        private CancellationTokenSource _cancellationTokenSource;

        private TcpListener _listener;
        private Task _listenerTask;

        public TcpListenerHandler(HandshakePipelineDelegate next)
        {
            _next = next;
        }

        public void Initialize(IPAddress address, int port)
        {
            _port = port;
            _listener = new TcpListener(address, port);
        }

        public void StartListener()
        {
            _listener.Start();
            _isRunning = true;
            _cancellationTokenSource = new CancellationTokenSource();
            _listenerTask = Task.Run(() => ListenerLoop(_cancellationTokenSource.Token));
        }

        public void StopListener()
        {
            _listener.Stop();
            _isRunning = false;
            _cancellationTokenSource.Cancel();
            _listenerTask.Wait();
        }

        private void ListenerLoop(CancellationToken token)
        {
            while (!token.IsCancellationRequested)
            {
                if (_listener.Pending())
                {
                    var client = _listener.AcceptTcpClient();
                    _next?.Invoke(client);
                }
                Thread.Sleep(3000);
            }
        }
    }
}
