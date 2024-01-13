using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Broker
{
    public interface IBroker
    {
        void PublishMessage<T>(object source, T message);
        void Subscribe<T>(Action<MessagePayload<T>> subscriptionAction);
        void Unsubscribe<T>(Action<MessagePayload<T>> subscriptionAction);
    }
}
