using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
namespace RemotingSamples
{
    public class RemoteObject : MarshalByRefObject
    {
        ///constructor
        public RemoteObject()
        {
            Console.WriteLine("Remote object activated");
        }
        ///return message reply
        public String ReplyMessage(String msg)
        {
            Console.WriteLine("Client : " + msg);//print given message on console 
            return "Server : Yeah! I'm here";
        }

        public int sum(int a, int b)
        {
            return a + b;
        }

        public MySerialized GetMySerialized()
        {
            return new MySerialized(500);
        }
    }

    /// <summary>
    /// This is a default Marshal by Value/serializable class
    /// By doing so will not create proxy. we can check with IsTransparentProxy
    /// </summary>
    [Serializable]
    public class MySerialized
    {
        protected int a;
        public MySerialized(int val)
        {
            a = val;
            Console.WriteLine("MySerialized A : {0}", a);
        }
    }
}
