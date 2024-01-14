using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking.ClientMessages
{
    public class TcpClientMessage
    {
        public string Head { get; private set; }
        public string Body { get; private set; }
        public string Signature { get; private set; }

        public TcpClientMessage(string head, string body, string signature)
        {
            Head = head;
            Body = body;
            Signature = signature;
        }
    }
}
