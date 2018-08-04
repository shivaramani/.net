using System;
/*
  Creational Pattern: deals with object creations mechanism
 
  Factory patterns defines an interface for creatina an object. 
  Lets the subclass decide which class to instantiate.
  
 Advantages of using factory pattern:

 1) Client code (Ex: MainClass) need not be tightly coupled with "NEW" / object creation. It is decided with the concrete factory class 
 * (EX: LogFactory below)
 2) Client need not know what types (ex: file or eventviewer) are available. 
 * If new type need to be introduced ex: MailLog it can just be introduced in factory and client can pass the value (ex:3).
 
 */
namespace factoryPatterns
{
    interface ILogger
    {
        void Log();
    }

    public class FileLog : ILogger
    {
        public FileLog() { }

        public void Log()
        {
            Console.WriteLine("Logged in File");
            Console.WriteLine();
        }
    }

    public class EventLog : ILogger
    {
        public EventLog() { }

        public void Log()
        {
            Console.WriteLine();
            Console.WriteLine("Logged in EventViewer");
            Console.WriteLine();
        }
    }

    public class LogFactory
    {
        public LogFactory()
        {

        }

        public void ProcessLog(int intLogType)
        {
            if (intLogType == 1)
            {
                ILogger fileLog = new FileLog();
                fileLog.Log();
            }
            else
            {
                ILogger eventLog = new EventLog();
                eventLog.Log();
            }
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            // Client calls only the concrete factory. Need not know what object needs to be created.
            // depending on log type it just needs to be passed

            LogFactory objLogFactory = new LogFactory();
            objLogFactory.ProcessLog(1);
            objLogFactory.ProcessLog(2);

            // assuming if new type is introduced (ex: MailLog) it can just be introduced in LogFactory. Client would just pass the type
            // objLogFactory.ProcessLog(3);
        }
    }
}