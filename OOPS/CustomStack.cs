using System;
using System.Collections.Generic;
using System.Text;
 
namespace Generics
{
    public class CustomStack<T>
    {
        const int size = 10;
        private T[] register;
        private int count = 0;
 
        public CustomStack()
        {
            register = new T[size];
        }
 
        public void Push(T x)
        {
            if (count < size)
                register[count++] = x;
        }
 
        public T Pop()
        {
            return register[--count];
        }     
   }
 
    public class Test
    {
        static void Main(string[] args)
        {
            CustomStack<int> intStack = new CustomStack<int>();
            intStack.Push(10);
            int i = intStack.Pop();
            Console.WriteLine(i);

            intStack.Push(20);
            i = intStack.Pop();
            Console.WriteLine(i);

            Console.Read();
        }
    }
}
