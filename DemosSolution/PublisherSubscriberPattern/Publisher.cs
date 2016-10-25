using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public class Publisher : IPublisher
    {
        public event PublisherHandler PublishEvents;
        private string _name;
        public Publisher(string name)
        {
            this._name = name;
        }
        public void AddSubscriptionManager(SubscriptionManager man)
        {
            this.PublishEvents += man.PublishEvents;
        }

        public void RemoveSubscriptionManger(SubscriptionManager man)
        {
            this.PublishEvents -= man.PublishEvents;
        }

        public void Notify(string msg)
        {
            Console.WriteLine("{0}发布消息：{1}", this._name, msg);
            if (PublishEvents != null)
            {
                PublishEvents(msg);
            }
        }
    }
}
