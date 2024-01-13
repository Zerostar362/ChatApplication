using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Code.Broker
{
    public class SimpleBroker : IBroker
    {
        private readonly Dictionary<Type, List<Delegate>> _subscribers;
        public SimpleBroker() 
        {
            _subscribers = new();
        }

        public void PublishMessage<T>(object source, T message)
        {
            if (message == null || source == null)
                return;
            if (!_subscribers.ContainsKey(typeof(T)))
            {
                return;
            }
            var delegates = _subscribers[typeof(T)];
            if (delegates == null || delegates.Count == 0) return;
            var payload = new MessagePayload<T>(source, message);
            foreach (var handler in delegates.Select
            (item => item as Action<MessagePayload<T>>))
            {
                Task.Factory.StartNew(() => handler?.Invoke(payload));
            }
        }

        public void Subscribe<T>(Action<MessagePayload<T>> subscriptionAction) 
        {
            var delegates = _subscribers.ContainsKey(typeof(T)) ?
                            _subscribers[typeof(T)] : new List<Delegate>();
            if (!delegates.Contains(subscriptionAction))
            {
                delegates.Add(subscriptionAction);
            }
            _subscribers[typeof(T)] = delegates;
        }

        public void Unsubscribe<T>(Action<MessagePayload<T>> subscriptionAction) 
        {
            if (!_subscribers.ContainsKey(typeof(T))) return;
            var delegates = _subscribers[typeof(T)];
            if (delegates.Contains(subscriptionAction))
                delegates.Remove(subscriptionAction);
            if (delegates.Count == 0)
                _subscribers.Remove(typeof(T));
        }
    }

    public class MessagePayload<T>
    {
        public object Sender { get; private set; }
        public T Message { get; private set;}

        public DateTime TimeSent {  get; private set; }

        public MessagePayload(object sender, T message)
        {
            Sender = sender;
            Message = message;
            TimeSent = DateTime.Now;
        }

    }
    }
}
