<Query Kind="Program" />

void Main()
{
    // Create Unicycle
    VehicleFactory.Build(1).Dump();
    
    // Create Car
    VehicleFactory.Build(2).Dump();
    
    // Create Motorbike
    VehicleFactory.Build(4).Dump();
    
    // Create Truck
    VehicleFactory.Build(5).Dump();
}

public interface IVehicle
{

}

public class Unicycle : IVehicle
{

}

public class Car : IVehicle
{

}

public class Motorbike : IVehicle
{

}

public class Truck : IVehicle
{

}

public static class VehicleFactory
{
    public static IVehicle Build(int numberOfWheels)
    {
        switch (numberOfWheels)
        {
            case 1:
                return new Unicycle();
            
            case 2:
            case 3:
                return new Motorbike();
            
            case 4:
                return new Car();
            
            default :
                return new Truck();
        }
    }
}
