using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.HandshakePipeline
{
    public class SSLCLient
    {
        private TcpClient _client;
        private SslStream _stream;

        public SSLCLient(TcpClient client, SslStream stream) 
        {
            _client = client;
            _stream = stream;
        }

        private async void ReadLoop(CancellationToken token)
        {
            var buffer = new byte[4096];
            while(!token.IsCancellationRequested)
            {
                var message = await _stream.ReadAsync(buffer); //publish the message
                await Task.Delay(100);
            }
        }

        public void SendData(byte[] message)
        {
            _stream.WriteAsync(message);
            _stream.Flush();
        }
    }
}
