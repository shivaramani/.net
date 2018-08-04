using System;

namespace GenericMax
{
   public class test
   {
        public static T Max<T>(T val1,T val2) where T: IComparable
        {
            T retVal = val2;
            if(val2.CompareTo(val1) < 0)
               retVal = val1;
            return retVal;
        }
     
        static void Main(string[] args)
        {
            int a=19, b=20;
            Console.WriteLine("Comparing INT : {0},{1}",a,b);
            int intMax = Max<int>(a,b);
            Console.WriteLine(intMax.ToString() + " is bigger.");
            Console.WriteLine();

            double d = 10.09, c = 21.90;
            Console.WriteLine("Comparing DOUBLE : {0},{1}", c, d);
            double doubleMax = Max<double>(c,d);
            Console.WriteLine(doubleMax.ToString() + " is bigger.");
            Console.WriteLine();

            string e = "A", f = "AA";
            Console.WriteLine("Comparing STRING : {0},{1}", e, f);
            string stringMax = Max<string>(e,f);
            Console.WriteLine(stringMax + " is bigger.");

        }
   }
}
