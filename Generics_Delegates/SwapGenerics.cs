using System;
//using System.Collections;//.Generic;
//using System.Text;
 
namespace SwapGenerics{ 
	public class MySwapClass
	{
		static void Main(string[] args)
		{
			// Swap two integers
			int a=10,b=20;
			Console.WriteLine("Before swapping int : {0},{1}", a,b);
			Swap<int>(ref a,ref b);
			Console.WriteLine("After swapping int : {0},{1}", a,b);
			Console.WriteLine();

			// Swap two strings
			string s1="10",s2="20";
			Console.WriteLine("Before swapping string : {0},{1}", s1,s2);
			Swap<string>(ref s1,ref s2);
			Console.WriteLine("After swapping string : {0},{1}", s1,s2);
			Console.WriteLine();
			//Console.ReadLine();
		}

		static void Swap <T>(ref T a, ref T b) 
		{
			//Console.WriteLine("You sent object {0} ", typeof(T));
			T temp;
			temp = a;
			a = b;
			b = temp;
		}
		
	}
}