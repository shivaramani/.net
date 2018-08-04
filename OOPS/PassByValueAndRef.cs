using System;

/// <summary>
/// Implicit value types (like int) are always passed by value by default
/// Object Types like array are implicitly passed by reference
/// </summary>
class ValueReferenceTypePass
{
  public static void Main(string[] args)
  {
     // Implicit Value types (like int) are always passed by value by default
      Console.WriteLine("Implicit Value types (like int) are always passed by value by default...");
      int i = 1;
     DoWorkDefault(i);
     Console.WriteLine("Value of i (even after passing to method) is : " + i);
     Console.WriteLine();

     int a;
     DoWork(out a);
     Console.WriteLine("Value of A after OUT is : "+a);  
     Console.WriteLine();

     int b = 3;
     Console.WriteLine("Value of B before REF (Require variable to be assigned) is : "+b);  
     DoWorkB(ref b);
     Console.WriteLine("Value of B after REF is : "+b);  
     Console.WriteLine();

     // Object Types are impicitly passed by reference
     int[] nums = {1,3,5};
     DoWorkObject(nums);

     Console.WriteLine("Object Types are impicitly passed by reference...");
     Console.WriteLine("Integer object array values are incremented by 1 after the method call");
     int count = 0;
     foreach(int n in nums)
     {
        Console.WriteLine("Value of a[{0}] is {1}", count++,n);
     }
     Console.WriteLine();

  }  
  public static void DoWorkObject(int[] numbers)
  {
	for(int i=0;i<numbers.Length;i++)
	{
	   numbers[i]++;
	}
  }  

  public static void DoWork(out int i)
  {
     i = 10;
  }
   
  public static void DoWorkB(ref int i)
  {
     i++;
  }

    static void DoWorkDefault(int i)
    {
        i = 20;
    }
}
