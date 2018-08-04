using System;

/// <summary>
/// Summary description for OOPsPrac
/// Samples of Polymorphism, Abstract Class, Interface, Indexers, Delegates & Events
/// </summary>
/// 
public class OOPsPrac
{
    public OOPsPrac()
    {
    }

    #region Polymorphism
    public class BaseClassPoly
    {
        public BaseClassPoly()
        {
            Console.WriteLine("Base class called (polymorphism)");
        }

        public string Welcome(string name)
        {
            return "Hi " + name;
        }

        public string DateDetails()
        {
            return "Todays date from base class : " + DateTime.Now.ToString();
        }

        public virtual string Welcome()
        {
            return "Base Virtual method message : Hi ";
        }
    }

    public class DerivedClassPoly : BaseClassPoly
    {
        public DerivedClassPoly()
        {
            Console.WriteLine("Derived class called (polymorphism)");
        }

        public new string Welcome(string name)
        {
            return "Derived class welcome message : Hi " + name;
        }

        public new string DateDetails()
        {
            return base.DateDetails();
            //return "Todays date from derived class : " + DateTime.Now.ToString();
        }

        public override string Welcome()
        {
            return "Derived class Overridden method message : Hi ";
        }
    }
    #endregion

    #region Abstract Class
    public class BaseClass
    {
        // virtual keyword mentions the method will be overridden in the base class
        public virtual int Add(int n1, int n2)
        {
            return n1 + n2;
        }
    }

    // Abstract class inhering from a base class
    // abstract class/ method need to be public (since they need to be overriden) & cannot be Sealed,private or protected
    public abstract class AbsClass : BaseClass
    {
        // abstract method can override the base class mthod
        // new keyword can also be usd to inform that the base method need to be hidden
        public override abstract int Add(int n1, int n2);
    }

    // class extending Abstract class
    public class AddClass : AbsClass
    {
        // below method overrides abstract class method
        public override int Add(int n1, int n2)
        {
            return n1 + n2;
        }
    }
    #endregion

    #region Interface
    interface IBase
    {
        string Name
        {
            set;
            get;
        }
    }

    class MyClass : IBase
    {
        private string _name;
        public MyClass()
        {

        }

        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
            }
        }
    }

    public class Control
    {
        public void SaveData()
        {
            Console.WriteLine("Conrol.SaveData.");
        }
    }

    // EditBox extends both Control & IDataStore
    // but implementation of SaveData is not provided. Would still compile !!!
    public class EditBox : Control, IDataStore
    {
        // Compiler looks for implementation of the Savedata method in Editbox 
        // and finds one in SaveData method inherited from Control class and 
        // NOT on actual implementation of IDataStore.SaveData. This is not as expected.
    }

    interface IDataStore
    {
        void SaveData();
    }

    interface ISerializabl
    {
        void SaveData();
    }

    class IFTest : ISerializabl, IDataStore
    {

        public void SaveData()
        {
            Console.WriteLine("Test.Savedata called.");
        }

        void IDataStore.SaveData()
        {
            Console.WriteLine("IDataStore.Savedata called.");
        }

        void ISerializabl.SaveData()
        {
            Console.WriteLine("ISerializabl.Savedata called.");
        }
    }

    #endregion

    #region Indexers
    public class IndexerClass
    {
        public IndexerClass()
        {

        }
        int[] arr = new int[3];

        // this indexer takes integer and sets/gets the value in that specific array position
        public int this[int idx]
        {
            get
            {
                if (idx >= 0 && idx < 3)
                    return arr[idx];
                else
                    return 0;
            }
            set
            {
                if (idx >= 0 && idx < 3)
                    arr[idx] = value;
            }

        }

        // this indexer accepts a day and returns the day in numbers (as string)
        public string this[string GivenDay]
        {
            get
            {
                return GetDays(GivenDay);
            }
        }

        string[] daysArr = { "sun", "mon", "tue", "wed", "thu", "fri", "sat" };

        private string GetDays(string GivenDay)
        {
            int retCount = 1;
            foreach (string day in daysArr)
            {
                if (day.ToUpper() == GivenDay.ToUpper())
                {
                    return retCount.ToString();
                }
                retCount++;
            }
            retCount = -1;
            return retCount.ToString();
        }


    }
    #endregion

    #region Delegates
    public delegate int AddSubDelegate(int n1, int n2);
    public class DelegateClass
    {
        public DelegateClass()
        {

        }

        public int Add(int n1, int n2)
        {
            return n1 + n2;
        }

        public int Sub(int n1, int n2)
        {
            return n1 - n2;
        }
    }
    #endregion

    #region Events
    /// <summary>
    /// To work with the events : 
    /// Define a public delegate for the event outside any class boundary
    /// Define a class to generate or raise the event
    /// Define a class to receive the events.
    /// </summary>
    /// <param name="args"></param>
    /// 
    public delegate void MyDelegate(object sender, object e);
    public class EventClass
    {
        public event MyDelegate ChangeEvent;
        public EventClass()
        {

        }

        private decimal price;

        public decimal Price
        {
            get
            {
                return price;
            }
            set
            {
                price = value;
                // Calls the event handler during setting price value
                ChangeEvent("Broker", value);
            }
        }


        public void ChangeEventMethod(object sender, object evnt)
        {
            Console.WriteLine("Event called for sender : {0} with value  : {1}", (string)sender, (decimal)evnt);
        }
    }
    #endregion

    #region Value & Reference types
    public class ValueAndRefClass
    {
        public ValueAndRefClass()
        {

        }

        public void DoWorkObject(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i]++;
            }
        }

        public void DoWork(out int i)
        {
            i = 10;
        }

        public void DoWorkB(ref int i)
        {
            i++;
        }
    }
    #endregion

    static void Main(string[] args)
    {
        #region Interface - Property caller
        Console.WriteLine();
        // Implementing property : Setting value to the property in IF extended class
        MyClass objMC = new MyClass();
        objMC.Name = "shiva";
        Console.WriteLine("Name provided (Interface) : " + objMC.Name);
        Console.WriteLine();

        IFTest objT = new IFTest();
        // Calling SaveData would be ambiguous (since both Interface has same method name). Compiler calls both implementation
        string strIsIdatastore = (objT is IDataStore) ? "Yes" : "No";
        string strIsISerializabl = (objT is IDataStore) ? "Yes" : "No";
        objT.SaveData();
        Console.WriteLine("Is IDataStore called : " + strIsIdatastore);
        Console.WriteLine("Is ISerializabl called : " + strIsISerializabl);
        Console.WriteLine();

        // To call a specific member of the interface casting can be done accordingly
        ((ISerializabl)objT).SaveData();
        ((IDataStore)objT).SaveData();
        Console.WriteLine();

        EditBox edit = new EditBox();
        edit.SaveData();
        Console.WriteLine();
        #endregion

        #region Abstract class - sum caller
        // Abstract class cannot be instantiated
        AddClass objAC = new AddClass();
        int sum = objAC.Add(2, 3);
        Console.WriteLine("Sum of two nos (using Abstract Class) : " + sum);
        Console.WriteLine();
        #endregion

        #region Polymorphism - callign base class/derived class methods
        // Polymorphism : Calling base class method
        BaseClassPoly objBCP = new BaseClassPoly();
        string strWelcomeBase = objBCP.Welcome();
        Console.WriteLine(strWelcomeBase);
        Console.WriteLine();

        // calling derived class & methods
        DerivedClassPoly objDCP = new DerivedClassPoly();
        string strWel = objDCP.Welcome("shiva");
        Console.WriteLine(strWel);
        Console.WriteLine(objDCP.DateDetails());
        Console.WriteLine(objDCP.Welcome());
        Console.WriteLine();
        #endregion

        #region Indexer - set & get for int & string indexers
        // Indexer. setting and getting values 
        IndexerClass objIC = new IndexerClass();
        objIC[1] = 1;
        objIC[0] = 0;
        objIC[2] = 2;
        // This value cannot be assigned as indexer size is only 3 (zero based)
        // Inside indexer setter : Value would be assignd as Zero as the index is outside bounds of the array 
        objIC[4] = 10;

        for (int i = 0; i <= 5; i++)
        {
            Console.WriteLine("Indexer value for objIC[" + i + "] : " + objIC[i]);
        }

        // Indexer can be overloaded. multiple indexers can co-exist in a class
        // below indexer returns String output for the day provided
        Console.WriteLine();
        string dayCount = objIC["FRI"];
        Console.WriteLine("Indexer day count for Friday : " + dayCount);
        Console.WriteLine();
        #endregion

        #region Delegates - sum/sub & multicast
        // delegates are references to method
        // Create an instance of the class & pass the method as reference to delegate object
        DelegateClass objDC = new DelegateClass();
        // Method can be passed as reference to delegate in below way also or can be assigned directly.
        // AddSubDelegate objAddSubDel = new AddSubDelegate(objDC.Add);
        AddSubDelegate objAddSubDel = objDC.Add;
        int delsum = objAddSubDel(1, 2);
        Console.WriteLine("Delegate := Sum & sub of 1 & 2 : " + delsum);

        // Multicast delegates
        Console.WriteLine();
        objDC = new DelegateClass();
        AddSubDelegate objAddSubMultiDel = null;
        objAddSubMultiDel = new AddSubDelegate(objDC.Add);
        objAddSubMultiDel += new AddSubDelegate(objDC.Sub);

        int delSumSub = objAddSubMultiDel(1, 2);
        Console.WriteLine("Multicast Delgate : Add & sub of 1,2 methods called: " + delSumSub);
        //removing sub method
        objAddSubMultiDel -= new AddSubDelegate(objDC.Sub);
        Console.WriteLine("Multicast Delgate : removing sub of 1,2 method : " + objAddSubMultiDel(1, 2));
        Console.WriteLine();
        #endregion

        #region Events
        // call event class & assign ChangeEvent with the corresponding handler
        EventClass objEC = new EventClass();
        objEC.ChangeEvent += new MyDelegate(objEC.ChangeEventMethod);
        // ChangeEvent is called everytime when the setter is called in EventClass
        objEC.Price = 10;
        objEC.Price = 20;
        Console.WriteLine();
        #endregion

        #region Value & Reference
        ValueAndRefClass objVAR = new ValueAndRefClass();
        // Implicit Value types (like int) are always passed by value
        int a;
        objVAR.DoWork(out a);
        Console.WriteLine("Value of A is :" + a);
        Console.WriteLine();

        int b = 3;
        Console.WriteLine("Value of B before REF is :" + b);
        objVAR.DoWorkB(ref b);
        Console.WriteLine("Value of B after REF is :" + b);
        Console.WriteLine();

        // Object Types are impicitly passed by reference
        int[] nums = { 1, 3, 5 };
        objVAR.DoWorkObject(nums);

        int count = 0;
        foreach (int n in nums)
        {
            Console.WriteLine("Value of a[{0}] is {1}", count++, n);
        }
        Console.WriteLine();
        #endregion
    }
}
