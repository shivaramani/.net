using System;
using System.Runtime.InteropServices;
class ExternSample
{
    // Using the extern modifier means that the method is implemented outside the C# code
    [DllImport("User32.dll")]
    public static extern int MessageBox(int h, string m, string c, int type);

    public static int Main()
    {
        string myString;
        Console.Write("Enter your message: ");
        myString = Console.ReadLine();
        // below code returns a messagebox run rom User32 dll using EXTERN
        return MessageBox(0, myString, "My Message Box", 0);
    }
}
