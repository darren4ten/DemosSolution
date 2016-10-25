using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubscriberPattern
{
    public class Subscriber
    {
        string _name;
        public Subscriber(string name)
        {
            _name = name;
        }

        public ISubscriber AddSubscriber { set { value.SubscriberEvents += Say; } }
        public ISubscriber RemoveSubscriber { set { value.SubscriberEvents -= Say; } }
        public void Say(string msg)
        {
            Console.WriteLine("订阅者{0}收到消息{1}", this._name, msg);
        }
    }
}
