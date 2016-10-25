using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public delegate void PublisherHandler(string msg);
    public interface IPublisher
    {
        event PublisherHandler PublishEvents;
        void AddSubscriptionManager(SubscriptionManager man);
        void RemoveSubscriptionManger(SubscriptionManager man);
        void Notify(string msg);
    }
}
