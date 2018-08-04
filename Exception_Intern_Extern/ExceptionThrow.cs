using System;

/// <summary>
/// Summary description for ThrowEx
/// </summary>
public class ThrowEx
{
    public ThrowEx()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public static int Divide(int y)
    {
        try
        {
            return 10 / y;
        }
        finally { }
    }

    public static int DivideByZero(int y)
    {
        try
        {
            return Divide(y);
        }
        catch
        {
            throw;// ex.Message.ToString();
        }

        finally
        {

        }

    }
    public static void Main(string[] args)
    {
        int x = 0;
        try
        {
            int y = DivideByZero(x);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Exception Source : " + ex.Source.ToString());
            Console.WriteLine("Exception StackTrace : " + ex.StackTrace.ToString());
            Console.WriteLine("Exception Message : " + ex.Message.ToString());
            Console.WriteLine("Exception InnerException : " + ex.InnerException);
            Console.WriteLine("Exception TargetSite : " + ex.TargetSite);
            Console.WriteLine("Exception Data : " + ex.Data);
        }
        //int z = DivideByZero(x);
    }
}