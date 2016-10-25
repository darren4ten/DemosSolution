using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public delegate void SubscriberHandler(string msg);
    public interface ISubscriber
    {
        event SubscriberHandler SubscribeEvents;

        void AddSubscriptionManager(SubscriptionManager man);
        void RemoveSubscriptionManger(SubscriptionManager man);

        void Show(string msg);
    }
}
