using System;
// declare delegate
delegate void MyDel(string msg);

class MainClass
{
 // Method that matches delegate signature
 static void MyDelMethod(string msg)
 {
     Console.WriteLine(msg);
 }

 static void Main()
 {
     // Instantiate delegate with named method
     MyDel d1 = MyDelMethod;
     // Invoke the delegate
     d1("Hello");
 }
}
