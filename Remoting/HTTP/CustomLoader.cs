using System;
using System.Text;
using System.IO;

namespace CustomerInfo
{
    public class CustomerLoader : System.MarshalByRefObject
    {
        public CustomerLoader()
        {
            // Console.WriteLine("New Customer Instance Created");
        }

        public string RetValue()
        {
            return "Message From CustomerLoader";
        }

    }
}
