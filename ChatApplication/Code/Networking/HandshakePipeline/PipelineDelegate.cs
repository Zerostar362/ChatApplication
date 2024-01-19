using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.HandshakePipeline
{
    public delegate void HandshakePipelineDelegate(TcpClient client, SslStream stream);
}
