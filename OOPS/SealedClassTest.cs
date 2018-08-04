using System;

/// <summary>
/// If you dont want the class to be inherited we can use Sealed class. So it cannot be used as base class.
/// Sealed class can be instantiated.
/// "ABSTRACT" modifier CANNOT be used in Sealed class
/// STRUCTS are implicityly sealed and cannot be inherited
/// </summary>
public sealed class SealedClass
{
    private SealedClass(){}
    public SealedClass(int A)
    { 
       this.x = A;
    }   

    public int x;
    public int y;
   
    public const string const1 = "const1";

}

class SealedClassTest
{
    static void Main()
    {
        // cannot do since SealedClass above has private constructor
        /*
        SealedClass sc = new SealedClass();
        sc.x = 110;
        sc.y = 150;
        Console.WriteLine(sc.x + "   " + sc.y);
	*/

	SealedClass sc = new SealedClass(5);
        Console.WriteLine(sc.x);

        // no issues accessing the constant inside teh sealed class. no instantiation is required.
	Console.WriteLine(SealedClass.const1);
    }
}