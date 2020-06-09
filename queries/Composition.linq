<Query Kind="Program" />

// Composition:
// -----------------------------------
// Description: 'part-of' relationship 
// -----------------------------------
// UML: Wheel  ----- <filled> Car
// -----------------------------------

void Main()
{
	Car car = new Car();
	car.AddWheelToWheels();
	car.AddWheelToWheels();
	car.AddWheelToWheels();
	car.AddWheelToWheels();
	
	car.Dump();
}

public class Wheel
{
	private int _wheels;
	
	public void AddWheel()
	{
		_wheels += 1;
	}

	public int GetWheels()
	{
		return _wheels;
	}
}

public class Car  
{
	public Wheel Wheel;
	
	public Car()  
	{  
		Wheel = new Wheel();
	}
	
	public void AddWheelToWheels()
	{
		Wheel.AddWheel();
	}
	
	public int GetWheels()
	{
		return Wheel.GetWheels();
	}
	
	public override string ToString() => $" Car. Wheels: {Wheel.GetWheels()}";
}