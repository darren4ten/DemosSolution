using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public class LogManagerSub : ISubscriber
    {
        public event SubscriberHandler SubscribeEvents;

        public void AddSubscriptionManager(SubscriptionManager man)
        {
            throw new NotImplementedException();
        }

        public void RemoveSubscriptionManger(SubscriptionManager man)
        {
            throw new NotImplementedException();
        }

        public void Show(string msg)
        {
            Console.WriteLine("写日志到数据库");
        }
    }
}
