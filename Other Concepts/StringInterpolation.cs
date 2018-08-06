using System;
using System.Collections.Generic;
using System.Linq;

namespace myApp
{
    class Program
    {
        static void Main()
        {
           var name = "...";
		   
		   // prints concatenated name with hello - traditional way
           Console.WriteLine("Hello " + name + "!");
		   
		   // prints just hello {name}
           Console.WriteLine("Hello {name}");
		   
		   // $ prepares the interpolation. prints interpolated string based on the variable
           Console.WriteLine($"Hello {name}");
		   
		   Console.WriteLine($"Hello {name.ToUpper()}");
		   
		   //string interpolation for a list
		   var names = new List<string>{"...","Shiva", "Ramani"};
           foreach(var nme in names){
               Console.WriteLine($"Hello {nme.ToUpper()}");
           }
		   
		   
		   // string interpolation can be done on other datatypes like dictionaries with formatting also		   
		   var inventory = new Dictionary<string, int>()
			  {
				  ["hammer, ball pein"] = 18,
				  ["hammer, cross pein"] = 5,
				  ["screwdriver, Phillips #2"] = 14
			  };

			Console.WriteLine($"Inventory on {DateTime.Now:d}");
			Console.WriteLine(" ");
			Console.WriteLine($"|{"Item",-25}|{"Quantity",10}|");
			foreach (var item in inventory)
			 Console.WriteLine($"|{item.Key,-25}|{item.Value,10}|");
        }
    }
}