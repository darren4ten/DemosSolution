using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubPattern2
{
    public class SubscriptionManager
    {
        string _managerName;
        public SubscriptionManager(string managerName)
        {
            this._managerName = managerName;
            this.PublishEvents += this.Notify;
        }

        public event SubscriberHandler SubscribeEvents;
        public PublisherHandler PublishEvents;

        public void Notify(string msg)
        {
            if (this.SubscribeEvents != null)
            {
                this.SubscribeEvents(msg);
            }
        }

    }
}
