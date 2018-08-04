using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
namespace RemotingSamples
{
    public class Server
    {
        ///constructor
        public Server()
        {
        }
        ///main method
        public static int Main(string[] args)
        {
            //select channel to communicate
            TcpChannel chan = new TcpChannel(8085);
            ChannelServices.RegisterChannel(chan); //register channel
            //register remote object
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(RemotingSamples.RemoteObject), "RemotingServer", WellKnownObjectMode.Singleton);
            //inform console
            Console.WriteLine("Server Activated");
            return 0;
        }
    }
}
