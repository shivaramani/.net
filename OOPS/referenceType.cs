using System;
using System.Text;

/// <summary>
/// Summary description for Class1
/// </summary>
public class referenceType
{
    public referenceType()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public struct IntHolder
    {
        public int i;
    }

    public static void Main(string[] args)
    {
        {
            StringBuilder first = new StringBuilder();
            StringBuilder second = first;
            first.Append("hello");
            first = null;
            Console.WriteLine("second: " + second.ToString());
            Console.WriteLine("first: " + first);
        }

        {
            IntHolder first = new IntHolder();
            first.i = 5;
            IntHolder second = first;
            first.i = 6;
            Console.WriteLine(second.i);
        }
    }
}
