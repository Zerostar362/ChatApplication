using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Broker.Messages
{
    public class NewClientMessage
    {
        public TcpClient NewClient { get; private set; }

        public NewClientMessage(TcpClient newClient)
        {
            NewClient = newClient;
        }
    }
}
