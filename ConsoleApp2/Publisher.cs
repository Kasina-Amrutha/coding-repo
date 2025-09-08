using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public delegate void MyDeligate(string msg);
    public class Publisher
    {
        public event MyDeligate MyEvent;
        public void EventMethod(string m)
        {
            MyEvent.Invoke("Publisher event Invoked with message " + m);
        }
    }
    public class Subscriber
    { 
        public void SubscriberMethod(string m)
        {
            Console.WriteLine("Subscriber Method called with message " + m); ;
        }
    }
}
