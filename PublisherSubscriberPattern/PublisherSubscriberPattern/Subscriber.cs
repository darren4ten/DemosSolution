using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public class Subscriber : ISubscriber
    {
        public event SubscriberHandler SubscribeEvents;
        string _name;
        public Subscriber(string name)
        {
            this._name = name;
        }

        public void AddSubscriptionManager(SubscriptionManager man)
        {
            man.SubscribeEvents += this.Show;
        }

        public void RemoveSubscriptionManger(SubscriptionManager man)
        {
            man.SubscribeEvents -= this.Show;
        }

        public void Show(string msg)
        {
            Console.WriteLine("{0}收到消息：{1}", this._name, msg);
        }
    }
}
