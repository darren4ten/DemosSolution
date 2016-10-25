using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubscriberPattern
{
    public class Publisher : IPublisher
    {
        string _name;
        public Publisher(string name)
        {
            _name = name;
        }

        public void Notify(string msg)
        {
            Console.WriteLine("发布者{0}发送消息{1}", this._name, msg);
            if (this.PublishEvents != null)
            {
                this.PublishEvents(msg);
            }
        }

        private event PublishHandler PublishEvents;

        event PublishHandler IPublisher.PublishEvents
        {
            add { PublishEvents += value; }
            remove { PublishEvents -= value; }
        }

    }
}
