using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubscriberPattern
{
    public class PubSubComponent : ISubscriber, IPublisher
    {
        string _name;
        public PubSubComponent(string name)
        {
            _name = name;
            this.PublishEvents += Notify;
        }

        public event SubscriberHandler SubscriberEvents;

        public PublishHandler PublishEvents;
        event PublishHandler IPublisher.PublishEvents
        {
            add { PublishEvents += value; }
            remove { PublishEvents -= value; }
        }
        public void Notify(string msg)
        {
            if (this.SubscriberEvents != null)
            {
                this.SubscriberEvents(msg);
            }
        }
    }
}
