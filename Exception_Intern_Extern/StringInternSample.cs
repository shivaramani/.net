// Sample for String.Intern(String)
using System;
using System.Text;

class StringInternSample
{
    /*
     you assign the same literal string to several variables, 
     the runtime retrieves the same reference to the literal string from the intern pool 
     and assigns it to each variable.
     The Intern method uses the intern pool to search for a string equal to the value of str. 
     If such a string exists, its reference in the intern pool is returned. 
     If the string does not exist, a reference to str is added to the intern pool, 
     then that reference is returned.
     */

    public static void Main()
    {
        String s1 = "MyTest";
        String s2 = new StringBuilder().Append("My").Append("Test").ToString();
        String s3 = String.Intern(s2);
        string s4 = new StringBuilder().Append("MyTest").ToString();
        string s5 = string.Intern(s4);

        Console.WriteLine("s1 = '{0}'", s1);
        Console.WriteLine("s2 = '{0}'", s2);
        Console.WriteLine("s3 = '{0}'", s3);
        Console.WriteLine("Is s2 the same reference as s1?: {0}", (Object)s2 == (Object)s1);
        Console.WriteLine("Is s3 the same reference as s1?: {0}", (Object)s3 == (Object)s1);
        Console.WriteLine("Is s5 the same reference as s1?: {0}", (Object)s5 == (Object)s1);

        // IsIntern
        // String str1 is known at compile time, and is automatically interned.
        String str1 = "abcd";

        // Constructed string, str2, is not explicitly or automatically interned.
        String str2 = new StringBuilder().Append("wx").Append("yz").ToString();

        // String str3 is interned becuase str1 is already assigned with the same value
        String str3 = new StringBuilder().Append("ab").Append("cd").ToString();
        Console.WriteLine();
        Test(1, str1);
        Test(2, str2);
        Test(3, str3);
    }

    public static void Test(int sequence, String str)
    {
        Console.Write("{0}) The string, '", sequence);
        String strInterned = String.IsInterned(str);
        if (strInterned == null)
            Console.WriteLine("{0}', is not interned.", str);
        else
            Console.WriteLine("{0}', is interned.", strInterned);
    }
}
/*
This example produces the following results:
s1 == 'MyTest'
s2 == 'MyTest'
s3 == 'MyTest'
Is s2 the same reference as s1?: False
Is s3 the same reference as s1?: True
*/
