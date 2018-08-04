using System;
using System.Threading;

/// <summary>
/// Summary description for Class1
/// </summary>
public class ThreadPrac
{
    public ThreadPrac()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static void ThreadMethodWithParam(int n1)
    {
        Console.WriteLine("Inside ThreadMethodWithParam : " + n1.ToString());
    }

    public static void ThreadMethod()
    {
        Console.WriteLine("Inside threadmethod");
        for (int i = 0; i <= 10000000; i++)
        {
            Thread.Sleep(3000);
        }
    }
    public static void ThreadMethod1()
    {
        Console.WriteLine("Inside threadmethod");
    }
    public static void Main(string[] args)
    {
        Thread t1 = new Thread(new ThreadStart(ThreadMethod1));
        t1.Name = "Thread Method";
        int intT1HashCode = t1.GetHashCode();
        t1.Start();

        Console.WriteLine("Name & Hashcode of Thread 1 : {0},{1}", t1.Name, intT1HashCode);
        Console.WriteLine();

        Thread t2;
        ThreadStart t2ThreadStartDel;
        t2ThreadStartDel = delegate { ThreadMethodWithParam(5); };
        t2 = new Thread(t2ThreadStartDel);
        t2.Start();
        Console.WriteLine("Thread 2 Name :{0}", t2.Name);
        Console.WriteLine("Thread 2 CurrentCulture & CurrentUICulture : {0},{1}", t2.CurrentCulture.ToString(), t2.CurrentUICulture.ToString());
        Console.WriteLine("Thread 2 ExecutionContext :{0}", t2.ExecutionContext);
        Console.WriteLine("Thread 2 IsAlive ? :{0}", t2.IsAlive);
        Console.WriteLine("Thread 2 IsThreadPoolThread ? :{0}", t2.IsThreadPoolThread);
        Console.WriteLine("Thread 2 ManagedThreadId :{0}", t2.ManagedThreadId);
        Console.WriteLine("Thread 2 ThreadState :{0}", t2.ThreadState);

        // Following properies cannot be accessesd since the thread is not ALIVE (DEAD)
        // Console.WriteLine("Thread 2 ApartmentState :{0}", t2.ApartmentState);
        // Console.WriteLine("Thread 2 IsBackground ? :{0}", t2.IsBackground);
        // Console.WriteLine("Thread 2 Priority :{0}", t2.Priority);
        Console.WriteLine();

        Thread t3 = new Thread(new ThreadStart(ThreadMethod));
        Console.WriteLine("Thread 3 : Starting ... ");
        t3.Start();
        Console.WriteLine("Thread 3 : About to sleep ");
        Thread.Sleep(1000);

        if (t3.IsAlive)
        {
            Console.WriteLine("Thread 3 : Suspending ...");
            t3.Suspend();
            t3.Resume();
            Console.WriteLine("Thread 3 : Resumed.");
        }

        try
        {
            CallThreadMethod(t3);
        }

        catch (ThreadAbortException tex)
        {
            Console.WriteLine("Thread 3 : ThreadAbortException" + tex.Message.ToString());
            Thread.ResetAbort();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error occured : " + ex.Message.ToString());
        }
    }

    public static void CallThreadMethod(Thread t3)
    {
        try
        {
            t3.Start();
            //t3.IsBackground = false;
            t3.Abort();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Thread 3 : Thread Priority =  " + t3.Priority);
            Console.WriteLine("Thread 3 : ThreadState =  " + t3.ThreadState);
            Console.WriteLine("Thread 3 : IsBackground ? = " + t3.IsBackground);
            Console.WriteLine("Thread 3 : Abort exception " + ex.Message.ToString());
            throw;
        }

    }
}
