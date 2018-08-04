using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class AttribPrac
{
    public AttribPrac()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
    public class Author : Attribute
    {
        private string _name;
        public double version;

        public Author(string name)
        {
            _name = name;
            version = 1.1;
        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                this._name = value;
            }
        }

        
    }

    [Author("Kalam")]
    public class FirstClass
    {

    }

    [Author("Kalam"),Author("Khera")]
    public class SecondClass
    {

    }

    [Author("Kalam"), Author("Khera")]
    public class ThirdClass
    {

    }

    public static void PrintValues(Type t)
    {
        Attribute[] attrs = Attribute.GetCustomAttributes(t);
        foreach (Attribute attr in attrs)
        {
            Author objA = attr as Author;
            if (objA != null)
            {
                Console.WriteLine("Name given : " + objA.Name);
                Console.WriteLine("Version : " + objA.version);
            }
        }
    }

    public static void Main(string[] args)
    {
        PrintValues(typeof(FirstClass));
        Console.WriteLine();
        PrintValues(typeof(SecondClass));
        Console.WriteLine();
        PrintValues(typeof(ThirdClass));
        Console.WriteLine();

    }
}
