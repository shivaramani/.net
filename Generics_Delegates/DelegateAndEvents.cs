using System;

public class DelegateAndEvents
{
    #region DELEGATE

    public delegate void MsgHandler(string s);

    public class DelegateMethod
    {
        public void SayHello(string Msg)
        {
            Console.WriteLine("Hello {0}", Msg);
        }
    }
    #endregion

    interface IEvent
    {
        // a notifier event based on the delegate
        event MsgHandler msgNotifier;
    }

    class EventClass : IEvent
    {
        public event MsgHandler msgNotifier
        {
            add
            {
                Console.WriteLine("Hello Add");
                msgNotifier += value;
            }

            remove
            {
                Console.WriteLine("Hello Remove");
                msgNotifier -= value;
            }
        }
    }

    public static void Main()
    {
        DelegateMethod objDelMethod = new DelegateMethod();

        MsgHandler objDelegate = new MsgHandler(objDelMethod.SayHello);
        objDelegate("shiva");


        EventClass objEventClass = new EventClass();
        
        // this will just pass the control to the event and will just keep calling
        objEventClass.msgNotifier += new MsgHandler(objDelMethod.SayHello);
        
        //Console.ReadLine();
    }
}
