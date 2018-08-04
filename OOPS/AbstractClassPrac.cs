using System;

/*
 * Abstract class (AC) cannot be instantiated
 * AC methods can reside only in abstract class
 * AC methods need to be overriden in the derived class
 * A Sealed class CANNOT be an abstract class
 * AC can derive from a non Abstract class,  an Abstract Class or an interface

*/
public abstract class AbstractClassPrac
{
    // abstract class can never be instantiated.
    public AbstractClassPrac()
    {
        Console.WriteLine("Abstact Class Constructor: ");
        Console.WriteLine("This will never be hit by instantiating (abstract class cannot be instantiated)");
        Console.WriteLine();
    }

    // Non abstract method. can be invoked like any other method
    public void Add(int x, int y)
    {
        Console.WriteLine("Normal method call in abstract class (invoked from derived class)");
        Console.WriteLine("Sum of x and y is {0} ", x + y);
        Console.WriteLine();
    }

    // provides the contract to be implemented.
    // abstract methods can reside only in abstract class
    // abstract method has to be implemented in the derived class otherwise it will result in compilation error
    public abstract void Sub(int x, int y);

}
class MainClass : AbstractClassPrac
{
    // this abstract method from base (abstract) class has to be implemented
    // this lets the deriving class perform their way of implementation
    public override void Sub(int x, int y)
    {
        Console.WriteLine("Overridden method in the derived class - Does the implementation");
        Console.WriteLine("Sub of x and y is {0} ", x - y);
        Console.WriteLine();
    }

    static void Main()
    {
        // abstract class cannot be instantiated as below
        // AbstractClassPrac objAbstract = new AbstractClassPrac();

        AbstractClassPrac objAbstract = new MainClass();
     
        // invoke abstract classes' non abstract method
        objAbstract.Add(10, 5);

        // invoke abstract method
        objAbstract.Sub(10, 5);
    }
}
