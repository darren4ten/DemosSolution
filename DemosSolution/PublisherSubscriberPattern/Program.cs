using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    class Program
    {
        static void Main(string[] args)
        {
            Subscriber sA = new Subscriber("订阅者A");
            Subscriber sB = new Subscriber("订阅者B");
            Publisher pa = new Publisher("发布者A");
            SubscriptionManager manager = new SubscriptionManager("订阅器A");

            sA.AddSubscriptionManager(manager);
            sB.AddSubscriptionManager(manager);
            pa.AddSubscriptionManager(manager);

            pa.Notify("小弟们，过来");
            sA.RemoveSubscriptionManger(manager);
            pa.Notify("再来");
            Console.ReadKey();
            
        }
    }
}
