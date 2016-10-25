using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubscriberPattern
{
    public delegate void PublishHandler(string msg);
    public interface IPublisher
    {
        event PublishHandler PublishEvents;
        void Notify(string msg);

    }
}
