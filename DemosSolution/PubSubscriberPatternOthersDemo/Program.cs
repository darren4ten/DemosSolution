﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSubscriberPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            MyPubSub();
            Console.Read();
        }
        static void MyPubSub()
        {
            PubSubComponent compA = new PubSubComponent("订阅器A");

            Subscriber subA = new Subscriber("订阅者A");
            Subscriber subB = new Subscriber("订阅者B");

            IPublisher pubA = new Publisher("发布者A");

            subA.AddSubscriber = compA;
            subB.AddSubscriber = compA;

            pubA.PublishEvents += compA.PublishEvents;


            //subA.RemoveSubscriber = compA;

            pubA.Notify("老板来了，快来开会");
        }
        //static void StandardPubSub()
        //{
        //    #region TJVictor.DesignPattern.SubscribePublish
        //    //新建两个订阅器
        //    SubPubComponet subPubComponet1 = new SubPubComponet("订阅器1");
        //    SubPubComponet subPubComponet2 = new SubPubComponet("订阅器2");
        //    //新建两个发布者
        //    IPublisher publisher1 = new Publisher("TJVictor1");
        //    IPublisher publisher2 = new Publisher("TJVictor2");
        //    //与订阅器关联
        //    publisher1.PublishEvent += subPubComponet1.PublishEvent;
        //    publisher1.PublishEvent += subPubComponet2.PublishEvent;
        //    publisher2.PublishEvent += subPubComponet2.PublishEvent;
        //    //新建两个订阅者
        //    Subscriber s1 = new Subscriber("订阅人1");
        //    Subscriber s2 = new Subscriber("订阅人2");
        //    //进行订阅
        //    s1.AddSubscribe = subPubComponet1;
        //    s1.AddSubscribe = subPubComponet2;
        //    s2.AddSubscribe = subPubComponet2;
        //    //发布者发布消息
        //    publisher1.Notify("博客1");
        //    publisher2.Notify("博客2");
        //    //发送结束符号
        //    Console.WriteLine("".PadRight(50, '-'));
        //    //s1取消对订阅器2的订阅
        //    s1.RemoveSubscribe = subPubComponet2;
        //    //发布者发布消息
        //    publisher1.Notify("博客1");
        //    publisher2.Notify("博客2");
        //    //发送结束符号
        //    Console.WriteLine("".PadRight(50, '-'));
        //    #endregion

        //    #region Console.ReadLine();
        //    Console.ReadLine();
        //    #endregion
        //}
    }
}
