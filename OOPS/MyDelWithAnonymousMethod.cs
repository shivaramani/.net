using System;
// declare delegate
delegate void MyDel(string msg);

class MainClass
{
    /*
        A delegate is a type that references a method.
        A delegate is a type that defines a method signature.
        when you instantiate a delegate, you can associate its instance with any method that matches with a compatible signature.
        The ability to refer methods makes delegates ideal for defining callback methods.
    
        Anonymous Methods: Before 2.0 we can only use "named" methods.
        Creating anonymous methods is essentially a way to pass a code block as a delegate parameter.
     
        In C# 3.0: Lambda expressions supersede anonymous methods
     
    */
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
     d1("Delegate with named method Invoked");


     // Instantiate delegate with anonymous method
     MyDel d2 = delegate(string msg)
     {
        Console.WriteLine(msg);
     };
     // Invoke the delegate
     d2("Anonymous delegate Invoked");
 }
}
