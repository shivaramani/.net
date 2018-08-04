using System;

public class DelegatePrac
{
    // delegates are references to methods
    /* 
     Difference between events and delegates
     
     1) Events can be part of an interface whereas delegates cannot be
     2) Events cannot be invoked by outside classes whereas delegates can be
     3) Events has additional accessors like Add / Remove
     
    */
    public delegate int delegateAdd(int firstNum, int secondNum);

    public class AddClass
    {
        public int Add(int i,int j)
        {
            return i+j;
        }        
    }

    public static void Main()
    {
        int i = 1;
        int j = 2;

        AddClass objAddClass = new AddClass();
        delegateAdd objDelAdd = new delegateAdd(objAddClass.Add);

        int sum = objDelAdd(i, j);

        Console.WriteLine("Sum of {0},{1} is {2}",i,j,sum);
    }

}
