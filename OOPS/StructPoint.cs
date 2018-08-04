using System;

/*
class and struct: encapsulates a set of dta and behavior that belong together as a logical unit

Class is a reference type
to achieve more complex behavior, oops like inheritance we can use
support inheritance

struct is a value type
suited for small data structures that contain primarily data not intended to be modified after the struct is created
doesn't support inheritance
*/
struct Point
{
	public double x;
	public double y;
	public Point (int x,int y)
	{
		this.x = x;
		this.y = y;

	}

	public override string ToString()
	{
		return "x = "+ x + "y = " +y ;
	}
}

class Test
{
	static void Main(string[] args)
	{
		Point pt = new Point(10,20);
		Console.WriteLine("Before changing point : {0}",pt);		
		Console.WriteLine();

		ChangeIt(pt);
		 
		// Even after changing the old values are displayed 
		// i.e Passed methods by values
		Console.WriteLine("After changing point : {0}",pt);		
		Console.WriteLine();

		// EVEN IF NEW IS NOT USED, we need to assign values to both x & y . otherwise build error
		Point ptNew;
		ptNew.y = 25;
		ptNew.x = 35;
		Console.WriteLine("After changing point : {0}",ptNew);		
		Console.WriteLine();

	}
	static void ChangeIt(Point pt)
	{
		pt.x = 5;
		pt.y = 8;
		Console.WriteLine("Inside ChangeIt point : {0}",pt);		
		Console.WriteLine();
	}
}
