<Query Kind="Program" />

// Composition:
// -----------------------------------
// Description: 'part-of' relationship 
// -----------------------------------
// UML: Engine  ----- <filled> Car
// -----------------------------------

void Main()
{
	// Create Car
	Car car = new Car("Tesla");
		
	// Print Car
	car.Dump();
	
	// Remove Car
	car = null;
	GC.Collect();
	
	// Print Car
	car.Dump();
}

public class Engine
{
	private string _type;
	private int _power;
	
	public Engine(string type, int power) {
		_type = type;
		_power = power;
	}
	
	public override string ToString() => $"Engine. Type: {_type}, Power: {_power}";
}

public class Car  
{
	private string _name;
	private Engine _engine;
	
	public Car(string name)  
	{  
		_name = name;
		_engine = new Engine("Electric", 100);
	}
	
	public override string ToString() {
		string result = $"Car. Name: {_name}";
		
		if (_engine != null)
			result += $"\n{_engine}";
			
		return result;
	}
}
