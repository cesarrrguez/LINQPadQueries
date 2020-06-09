<Query Kind="Program" />

// Heritage:
// --------------------------------
// Description: 'is-a' relationship
// --------------------------------
// UML: Square    -----|> Shape
//      Rectangle -----|> Shape
//      Circle    -----|> Shape
// --------------------------------

void Main()
{
	Shape[] shapes = { new Rectangle(10, 12), new Square(5), new Circle(3) };

	foreach (var shape in shapes) {
		Console.WriteLine($"\n{shape}. Area: {Shape.GetArea(shape)}, " + $"Perimeter: {Shape.GetPerimeter(shape)}");

		var rect = shape as Rectangle;
		if (rect != null) {
			Console.WriteLine($"   Is Square: {rect.IsSquare()}, Diagonal: {rect.Diagonal}");
			continue;
		}

		var sq = shape as Square;
		if (sq != null) {
			Console.WriteLine($"   Diagonal: {sq.Diagonal}");
			continue;
		}
	}
}

public abstract class Shape
{
	public abstract double Area { get; }
	public abstract double Perimeter { get; }
	
	public static double GetArea(Shape shape) => shape.Area;
	public static double GetPerimeter(Shape shape) => shape.Perimeter;
	
	public override string ToString() => GetType().Name;
}

public class Square : Shape
{
	public double Side { get; }
	public double Diagonal => Math.Round(Math.Sqrt(2) * Side, 2);
	public override double Area => Math.Pow(Side, 2);
	public override double Perimeter => Side * 4;	
	
	public Square(double length)
	{
		Side = length;
	}
}

public class Rectangle : Shape
{
	public double Length { get; }
	public double Width { get; }
	public double Diagonal => Math.Round(Math.Sqrt(Math.Pow(Length, 2) + Math.Pow(Width, 2)), 2);
	public override double Area => Length * Width;
	public override double Perimeter => 2 * Length + 2 * Width;

	public Rectangle(double length, double width)
	{
		Length = length;
		Width = width;
	}
	
	public bool IsSquare() => Length == Width;
}

public class Circle : Shape
{
	public double Radius { get; }
	public double Diameter => Radius * 2;
	public override double Area => Math.Round(Math.PI * Math.Pow(Radius, 2), 2);
	public override double Perimeter => Math.Round(Math.PI * 2 * Radius, 2);
	public double Circumference => Perimeter;
	
	public Circle(double radius)
	{
		Radius = radius;
	}
}