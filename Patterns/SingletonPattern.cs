using System;
/*
  Creational Pattern: deals with object creations mechanism
 
  Only one instance can be created. keywords like private constructor, static readonly are used
 
  Advantage(s) of using factory pattern:

 1) Lazy initialization can be done to make sure one instance is created and used
 2) Thread safety is guaranteed by the compiler
 
 */
namespace SingletonPattern
{
    public class Singleton  
    {
        private static Singleton _instance;

        protected Singleton() { }

        public static Singleton Instance()
        {
            if (_instance == null)
            {
                Console.WriteLine("Called first time inside the singleton clas");
                Console.WriteLine();
                _instance = new Singleton();
            }
            Console.WriteLine("Called everytime inside the singleton class");
            Console.WriteLine();
            return _instance;
        }
    }

    public class MainClass
    {
        public static void Main()
        {
            Console.WriteLine("Called first time from the invoking class");
            Console.WriteLine();
            Singleton s1 = Singleton.Instance();

            Console.WriteLine("Called second time from the invoking class");
            Console.WriteLine();
            Singleton s2 = Singleton.Instance();     
        }
    }
}