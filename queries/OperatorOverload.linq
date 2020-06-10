<Query Kind="Program" />

void Main()
{
    var object1 = new MyObject{Property1 = 1, Property2 = 2, Property3 = 3};
    var object2 = new MyObject{Property1 = 1, Property2 = 2, Property3 = 3};

    var result = object1 == object2;
    result.Dump();
}

public class MyObject {
    public int Property1 { get; set; }
    public int Property2 { get; set; }
    public int Property3 { get; set; }
    
    public static bool operator ==(MyObject obj1, MyObject obj2)
    {
        return obj1?.Property1 == obj2?.Property1 && obj1?.Property2 == obj2?.Property2 && obj1?.Property3 == obj2?.Property3;
    }
    
    public static bool operator !=(MyObject obj1, MyObject obj2)
    {
        return obj1?.Property1 != obj2?.Property1 || obj1?.Property2 != obj2?.Property2 || obj1?.Property3 != obj2?.Property3;
    }
}
