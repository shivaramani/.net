using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using RemotingSamples;
//using RemoteObject;
namespace RemotingSamples
{
    public class Client
    {
        ///constructor
        public Client()
        {
        }
        ///main method
        public static int Main(string[] args)
        {
            //select channel to communicate with server
            TcpChannel chan = new TcpChannel();
            ChannelServices.RegisterChannel(chan);
            // RemoteObject class is the class library object - remoteobject.cs
            RemoteObject remObject = new RemoteObject();
            remObject = (RemoteObject)Activator.GetObject(typeof(RemoteObject), "tcp://localhost:8085/RemotingServer");
            if (remObject == null)
                Console.WriteLine("cannot locate server");
            else
            {
                try
                {
                    remObject.ReplyMessage("You there?");
                    int i = (remObject.sum(1, 2));
                    Console.WriteLine(i.ToString());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error occured : " + ex.Message.ToString());
                }
            }
            
            Console.WriteLine("calling GetMySerialized...");
            try
            {
                MySerialized objMys = remObject.GetMySerialized();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception calling MySerialized: {0}", ex.Message); 
            }
                Console.WriteLine("GetMySerialized Done...");

            return 0;

        }
    }
}
