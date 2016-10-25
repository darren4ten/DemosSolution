using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public class EmailManagerSub : ISubscriber
    {
        public event SubscriberHandler SubscribeEvents;

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
            Console.WriteLine("发送邮件给用户");
        }
    }
}
