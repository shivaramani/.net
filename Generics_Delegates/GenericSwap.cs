using System;

namespace GenericSwap
{
    public class Test
    {
        static void swap<T>(ref T a, ref T b)
        {
            T temp;
            temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Swapping INT");
            int a = 10;
            int b = 20;
            Console.WriteLine("Before swapping : {0},{1}", a, b);
            swap<int>(ref a, ref b);
            Console.WriteLine("After swapping : {0},{1} ", a, b);
            Console.WriteLine();

            Console.WriteLine("Swapping STRING");
            string s1 = "first";
            string s2 = "second";
            Console.WriteLine("Before swapping : {0},{1} ", s1, s2);
            swap<string>(ref s1, ref s2);
            Console.WriteLine("After swapping : {0},{1} ", s1, s2);
            // Console.ReadLine();
        }
    }
}
