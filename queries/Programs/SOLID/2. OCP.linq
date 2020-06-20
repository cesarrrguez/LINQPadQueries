<Query Kind="Program" />

// OCP (Open/Closed Principle)
// ------------------------------------------------------------------
// A class should be open for extension, but closed for modification.
// ------------------------------------------------------------------

void Main()
{
    // Not OCP
    var rectangle = new Rectangle
    {
        Width = 30,
        Heigth = 60
    };
    
    AreaCalculator.CalculateArea(rectangle);
   
    // OCP
    var square = new Square
    {
        Side = 50
    };
    
    var circle = new Circle
    {
        Radius = 30
    };
    
    AreaCalculator_OCP.CalculateArea(square);
    AreaCalculator_OCP.CalculateArea(circle);
}

// Not OCP
// --------------------------
public class Rectangle
{
    public double Width {get; set;}
    public double Heigth {get; set;}
}

public class AreaCalculator
{
    public static void CalculateArea(Rectangle rectangle)
    {
        var area = rectangle.Width * rectangle.Heigth;
        
        Console.WriteLine($"Rectangle area: {area}\n");
    }
}

// OCP
// --------------------------
public interface IShape
{
    double GetArea();
}

public class Square : IShape
{
    public double Side { get; set; }
    public double GetArea() => Math.Pow(Side, 2);
}

public class Circle : IShape
{
    public double Radius { get; set; }
    public double GetArea() => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
}

public class AreaCalculator_OCP
{
    public static void CalculateArea(IShape shape)
    {
        var area = shape.GetArea();
        
        Console.WriteLine($"{shape.GetType().Name} area: {area}\n");
    }
}