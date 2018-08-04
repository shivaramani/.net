using System;
class Point
{
    public int x;
    public int y;
}
class A
{
    protected int x = 123;
    protected int y = 800;
}
class Employee
{
    private string name = "Shiva, Ramani";
    private double salary = 100.0;

    public string GetName()
    {
        return name;
    }

    public double Salary
    {
        get { return salary; }
    }
}
class B : A
{
    static void Main()
    {
        Point p = new Point();
        // Direct access to public members:
        p.x = 10;
        p.y = 15;
        Console.WriteLine("Public variables : x = {0}, y = {1}", p.x, p.y);

        A a = new A();
        B b = new B();

        // Error CS1540, because x can only be accessed by
        // classes derived from A.
        // a.x = 10; 

        // OK, because this class derives from A.
        b.x = 10;
        //b.y = 20;
        Console.WriteLine("Protected variables : b.x = {0}", b.x);
        Console.WriteLine("Protected variables : b.y = {0}", b.y);

        Employee e = new Employee();

        // The data members are inaccessible (private), so
        // then can't be accessed like this:
        //    string n = e.name;
        //    double s = e.salary;

        // 'name' is indirectly accessed via method:
        string name = e.GetName();

        // 'salary' is indirectly accessed via property
        double sal = e.Salary;

        Console.WriteLine("Private variables : name = {0},sal = {1}", name, sal);
    }
}

