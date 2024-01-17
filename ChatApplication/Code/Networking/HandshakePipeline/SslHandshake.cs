using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.HandshakePipeline
{
    public class SslHandshake
    {
        private string certificatePath = "ChatApp.crt";

        private HandshakePipelineDelegate _next;
        public SslHandshake(HandshakePipelineDelegate next)
        {
            _next = next;
        }

        public void DoHandShake(TcpClient client)
        {
            SslStream sslStream = new SslStream(client.GetStream(), false);

            try
            {
                sslStream.AuthenticateAsServer(new SslServerAuthenticationOptions() { });
            }
        }
    }
}
