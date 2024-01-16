using ChatApplication.Code.Broker;
using ChatApplication.Code.Broker.Messages;
using ChatApplication.Code.Networking.HandshakePipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Networking
{
    public class TcpHandler
    {
        private TcpListenerHandler _listener;
        private TcpHandler _tcpHandler;
        private IBroker _broker;

        public TcpHandler(IBroker broker)
        {
            _broker = broker;
        }

        public void Initialize()
        {
            _broker.Subscribe<NewClientMessage>(NewClientReceived);
        }

        private void NewClientReceived(MessagePayload<NewClientMessage> message)
        {

        }
    }
}
