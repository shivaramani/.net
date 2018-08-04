using System;

public class NonGenericSwap
{
    // Normal Swapping
    static void Swap(ref int a, ref int b)
    {
        int temp;
        temp = a;
        a = b;
        b = temp;
    }

    // typed Swapping - generics
    // pass type as parameters
    // caller code has the flexibility to pass any type to achieve the functionality (ex: T can be int/float/string etc)
    static void TypeSwap <T>(ref T a, ref T b)
    {
        T temp;
        temp = a;
        a = b;
        b = temp;
    }

    
    public static void Main()
    {
        int a = 10;
        int b = 20;
        Console.WriteLine("Before swapping - normal swap : {0},{1}", a, b);
        Swap(ref a,ref b);
        Console.WriteLine("After swapping  - normal swap : {0},{1}", a, b);

        Console.WriteLine();

        // Typed Swapping (Generics)
        a = 10;
        b = 20;
        Console.WriteLine("Before swapping - Generics Swap : {0},{1}", a, b);
        TypeSwap<int>(ref a, ref b);
        Console.WriteLine("After swapping  - Generics Swap : {0},{1}", a, b);


        Console.WriteLine();

        // Typed Swapping (Generics) - STRING
        string A = "TEN";
        string B = "TWENTY";
        Console.WriteLine("Before swapping - Generics Swap : {0},{1}", A, B);
        TypeSwap<string>(ref A, ref B);
        Console.WriteLine("After swapping  - Generics Swap : {0},{1}", A, B);
    }
}
