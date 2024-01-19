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

        public override string ToString()
        {
            var builder = new StringBuilder();

            builder.Append(Head);
            builder.Append(".");
            builder.Append(Body);
            builder.Append(".");
            builder.Append(Signature);

            return builder.ToString();
        }
    }
}
