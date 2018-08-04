abstract class Shape
{
    public const double pi = System.Math.PI;
    protected double x, y;

    public Shape()
    {
    }

    public Shape(double x, double y)
    {
        this.x = x;
        this.y = y;
    }

    public abstract double Area();
}

class Circle : Shape
{
    //If a base class does not offer a default constructor, the derived class must make an explicit call to a base constructor using "base".
    public Circle(double radius) : base(radius, 0)
    {
    }
    public override double Area()
    {
        return pi * x * x;
    }
}

class Cylinder : Circle
{
    public Cylinder(double radius, double height)
        : base(radius)
    {
        y = height;
    }

    public override double Area()
    {
        return (2 * base.Area()) + (2 * pi * x * y);
    }
}

class Square : Shape
{
    public Square(double side): base(side,0)
    {
        // below assignment of value is NOT required as the code extends base constructor.
        //x = side;
    }
    public override double Area()
    {
        return x * x;
    }
}

class Rectangle : Shape
{
    // Since Shape has default constructor, base(length,breadth) need not be provided
    // Absence of default constructor in base class would throw below error :
    // "No overload for method 'Shape' takes '0' Arguments "
    public Rectangle(double length, double breadth) //: base(length,breadth)
    {
        // since base is not provided above, default values need to be assigned as below basd on parameters
        // as otherwise value would be ZERO even if its passd from caller code.
        x = length;
        y = breadth;
    }
    public override double Area()
    {
        return (x * y);
    }
}


class TestShapes
{
    static void Main()
    {
        double radius = 2.5;
        double height = 3.0;
        double side = 4.0;
        double length = 4.0;
        double breadth = 5.0;

        Circle ring = new Circle(radius);
        Cylinder tube = new Cylinder(radius, height);
        Square sq = new Square(side);
        Rectangle rect = new Rectangle(length, breadth);

        System.Console.WriteLine("Area of the circle = {0:F2}", ring.Area());
        System.Console.WriteLine("Area of the cylinder = {0:F2}", tube.Area());
        System.Console.WriteLine("Area of the Square = {0:F2}", sq.Area());
        System.Console.WriteLine("Area of the Rectangle = {0:F2}", rect.Area());
    }
}

