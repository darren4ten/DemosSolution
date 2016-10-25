using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubscriberPattern
{
    public delegate void SubscriberHandler(string msg);
    public interface ISubscriber
    {
        event SubscriberHandler SubscriberEvents;
    }
}
