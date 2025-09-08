using ConsoleApp2;
Publisher p = new Publisher();
Subscriber s = new Subscriber();
p.MyEvent += s.SubscriberMethod;
p.EventMethod("Method Parameter");
Console.WriteLine();
